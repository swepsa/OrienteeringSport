using System;
using System.Collections.Generic;
using UnityEngine;

public class Competition : MonoBehaviour
{
    protected Route routeMan;
    protected Route routeWoman;

    public Route RouteMan { get => routeMan; protected set => routeMan = value; }
    public Route RouteWoman { get => routeWoman; set => routeWoman = value; }
    public StartsPlace StartsPlace { get; protected set; }
    public float ScaleMap { get; private set; }

    public class CompetitionCreator : Competition
    {
        private CompetitionEvent cEvent;
        private MapDataProvider mapDataProvider;
        private FinishPlace finishPlace;
        private Transform rootRoute;

        private void Awake()
        {
            rootRoute = GameObject.Find("Route").transform;
        }

        public Competition Create(CompetitionEvent cEvent)
        {
            this.cEvent = cEvent;
            CreateTerrain(cEvent.TerrainName);
            CreateStartsFinishPlaces();
            СreateRoutes();
            return this;
        }

        private void CreateTerrain(string terrainName)
        {
            GameObject terrainPrefab = Resources.Load(terrainName, typeof(GameObject)) as GameObject;
            GameObject terrain = Instantiate(terrainPrefab, new Vector3(), Quaternion.identity);
            terrain.name = "Terrain";
            mapDataProvider = terrain.GetComponent<MapDataProvider>();
            ScaleMap = mapDataProvider.MapScale;
        }

        private void CreateStartsFinishPlaces()
        {
            int countPlaces = mapDataProvider.StartPlaces.Count;
            int index = new System.Random().Next(countPlaces);
            StartsPlace = mapDataProvider.StartPlaces[index];

            Transform startPrefab = Resources.Load("Start", typeof(Transform)) as Transform;
            Transform start = Instantiate(startPrefab, StartsPlace.Position, Quaternion.Euler(StartsPlace.Rotation), rootRoute);
            start.name = "Start";

            finishPlace = mapDataProvider.FinishPlaces[index];
            if (finishPlace != null)
            {
                Transform finishPrefab = Resources.Load("Finish", typeof(Transform)) as Transform;
                Transform finish = Instantiate(finishPrefab, finishPlace.position, Quaternion.Euler(finishPlace.rotation), rootRoute);
                finish.name = "Finish";
            }
        }

        private void СreateRoutes()
        {
            int IndexOfNearestControlPoint = FindIndexOfNearestControlPoint();
            List<ControlPoint> needfulControlPoints = NeedfulControlPoints();
            CreateRoutes();
            InstantiateControlPoints();

            int FindIndexOfNearestControlPoint()
            {
                if (mapDataProvider.ControlPoints.Count == 0) { throw new Exception("Exception. List of control points can not empty."); }
                int index = 0;
                float distance = float.MaxValue;
                foreach (ControlPoint cp in mapDataProvider.ControlPoints)
                {
                    float tempDistance = Vector3.Distance(StartsPlace.Position, cp.Position);
                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        index = mapDataProvider.ControlPoints.IndexOf(cp);
                    }
                }
                return index;
            };

            List<ControlPoint> NeedfulControlPoints()
            {
                needfulControlPoints = new List<ControlPoint>();
                int startIndex, endIndex;
                int step = StartsPlace.ForwardDirection ? 1 : -1;

                // Part 1
                startIndex = IndexOfNearestControlPoint;
                endIndex = StartsPlace.ForwardDirection ? mapDataProvider.ControlPoints.Count : 0;
                addPartOfControlPoints();

                // Part 2
                endIndex = IndexOfNearestControlPoint;
                startIndex = StartsPlace.ForwardDirection ? 0 : mapDataProvider.ControlPoints.Count;
                addPartOfControlPoints();

                return needfulControlPoints;

                void addPartOfControlPoints()
                {
                    for (int i = startIndex; i != endIndex; i += step)
                    {
                        ControlPoint item = mapDataProvider.ControlPoints[i];
                        float distance = Vector3.Distance(StartsPlace.Position, item.Position);

                        if (distance < Constants.MINIMAL_DISTANCE_FROME_START_TO_CONTROL_POINT || distance > cEvent.CompetitionTypeByLenght.MaxDistanceFromStartToControlPoint)
                        {
                            continue;
                        }
                        if (!needfulControlPoints.Contains(item))
                        {
                            needfulControlPoints.Add(item);
                        }
                    }
                }
            };

            void CreateRoutes()
            {
                System.Random random = new System.Random();
                int countOfControlPoints = random.Next(cEvent.CompetitionTypeByLenght.MinCountOfControlPoints, cEvent.CompetitionTypeByLenght.MaxCountOfControlPoints);
                float step = (float)needfulControlPoints.Count / countOfControlPoints;
                RouteMan = CreateRoute();
                RouteWoman = CreateRoute();
                if (RouteMan.LenghtRoute < RouteWoman.LenghtRoute)
                {
                    Utils.Swap<Route>(ref routeMan, ref routeWoman);
                }

                Route CreateRoute()
                {
                    Route route = new Route();
                    Vector3 previosPosition = StartsPlace.Position;
                    for (float i = 0; i < needfulControlPoints.Count; i += step)
                    {
                        int index = (int)Math.Round(i + Math.Min(step, random.Next((int)Math.Round(step))));
                        index = Math.Min(index, needfulControlPoints.Count - 1);

                        float distanceFromPreviousPosition = Vector3.Distance(previosPosition, needfulControlPoints[index].Position);
                        if (distanceFromPreviousPosition == 0)
                        {
                            continue;
                        }
                        RouteSegment routeSegment = new RouteSegment(needfulControlPoints[index], distanceFromPreviousPosition);
                        route.AddRouteSegment(routeSegment);
                        previosPosition = needfulControlPoints[index].Position;
                    }
                    return route;
                };
            };

            void InstantiateControlPoints()
            {
                Transform controlPointPrefab = Resources.Load("ControlPoint", typeof(Transform)) as Transform;
                Transform lastInstanceCP = null;
                int counter = 31;
                int indexManRoute = 0;
                int indexWomanRoute = 0;
                ControlPoint manCp = null, womanCp = null, currentCP;
                int idManCP = 0, idWomanCP = 0;

                while (indexManRoute != -1 && indexManRoute != -1)
                {

                    if (indexManRoute != -1)
                    {
                        manCp = RouteMan.RouteSegments[indexManRoute].ControlPoint;
                        idManCP = needfulControlPoints.IndexOf(manCp);
                    }

                    if (indexWomanRoute != -1)
                    {
                        womanCp = RouteWoman.RouteSegments[indexWomanRoute].ControlPoint;
                        idWomanCP = needfulControlPoints.IndexOf(womanCp);
                    }

                    if (idManCP < idWomanCP)
                    {
                        currentCP = manCp;
                        indexManRoute++;
                    }
                    else if (idManCP > idWomanCP)
                    {
                        currentCP = womanCp;
                        indexWomanRoute++;
                    }
                    else
                    {
                        currentCP = manCp;
                        womanCp.name = "CP" + (counter).ToString();
                        indexManRoute++;
                        indexWomanRoute++;
                    }

                    currentCP.name = "CP" + (counter).ToString();
                    lastInstanceCP = Instantiate(controlPointPrefab, currentCP.Position, Quaternion.identity, rootRoute);
                    lastInstanceCP.name = currentCP.name;

                    counter++;

                    if (indexManRoute == RouteMan.RouteSegments.Count) { indexManRoute = -1; }
                    if (indexWomanRoute == RouteWoman.RouteSegments.Count) { indexWomanRoute = -1; }
                }

                if (finishPlace == null)
                {
                    int manLastNumberCP = Int32.Parse(manCp.GetNumber());
                    int womanLastNumberCP = Int32.Parse(womanCp.GetNumber());

                    if (manLastNumberCP < womanLastNumberCP)
                    {
                        RouteMan.RemoveLastSegment();
                        currentCP = RouteWoman.GetLastControlPoint();
                        GameObject cp = GameObject.Find(currentCP.name);
                        cp.name = Constants.LAST_CONTROL_POINT_NAME;
                        currentCP.name = cp.name;
                        RouteMan.AddRouteSegment(new RouteSegment(currentCP, Vector3.Distance(RouteMan.GetLastControlPoint().Position, currentCP.Position)));
                    }
                    else if (manLastNumberCP > womanLastNumberCP)
                    {
                        RouteWoman.RemoveLastSegment();
                        currentCP = RouteMan.GetLastControlPoint();
                        GameObject cp = GameObject.Find(currentCP.name);
                        cp.name = Constants.LAST_CONTROL_POINT_NAME;
                        currentCP.name = cp.name;
                        RouteWoman.AddRouteSegment(new RouteSegment(currentCP, Vector3.Distance(RouteWoman.GetLastControlPoint().Position, currentCP.Position)));
                    }
                    else
                    {
                        manCp.name = Constants.LAST_CONTROL_POINT_NAME;
                        womanCp.name = Constants.LAST_CONTROL_POINT_NAME;
                        lastInstanceCP.name = Constants.LAST_CONTROL_POINT_NAME;
                    };
                }
                else
                {
                    lastInstanceCP = Instantiate(controlPointPrefab, finishPlace.positionCP100.Position, Quaternion.identity, rootRoute);
                    lastInstanceCP.name = finishPlace.positionCP100.name;
                    RouteMan.AddRouteSegment(new RouteSegment(finishPlace.positionCP100, Vector3.Distance(RouteMan.GetLastControlPoint().Position, finishPlace.positionCP100.Position)));
                    RouteWoman.AddRouteSegment(new RouteSegment(finishPlace.positionCP100, Vector3.Distance(RouteWoman.GetLastControlPoint().Position, finishPlace.positionCP100.Position)));

                    GameObject finishGameObject = GameObject.Find("Finish");
                    Transform finishTransform = finishGameObject.transform.Find("CPFinish");
                    ControlPoint cpFinish = new ControlPoint(Constants.FINISH_CONTROL_POINT_NAME, finishTransform.position);
                    RouteMan.AddRouteSegment(new RouteSegment(cpFinish, Vector3.Distance(RouteMan.GetLastControlPoint().Position, cpFinish.Position)));
                    RouteWoman.AddRouteSegment(new RouteSegment(cpFinish, Vector3.Distance(RouteWoman.GetLastControlPoint().Position, cpFinish.Position)));
                }
            }
        }
    }
}
