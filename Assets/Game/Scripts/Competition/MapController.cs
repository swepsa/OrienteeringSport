using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// using with MapPicture on the scene 
public class MapController : MonoBehaviour
{
    public Transform startMapObj;
    public Transform controlPointMapObj;
    public Transform lineMapObj;
    public Text numberCPMapObj;
    public Transform finishMapObj; 

    public readonly List<Transform> mapObjects = new List<Transform>();
    public float ScaleMap { get; private set; }

    public void Draw(Vector3 startPosition, List<RouteSegment> routeSegments, float scaleMap)
    {
        ScaleMap = scaleMap;
        float offsetX = 300f;
        float offsetZ = 60f;
        const float dCircle = 30f;

        //Draw start
        float x = startPosition.x * scaleMap + offsetX;
        float z = startPosition.z * scaleMap + offsetZ;

        float xn = routeSegments[0].ControlPoint.Position.x * scaleMap + offsetX;
        float zn = routeSegments[0].ControlPoint.Position.z * scaleMap + offsetZ;

        Transform mapObject = Instantiate(startMapObj, new Vector3(x, z, 0), Quaternion.Euler(0, 0, (180 / Mathf.PI) * Mathf.Atan2((zn - z), (xn - x)) - 90)) as Transform;

        mapObject.SetParent(gameObject.transform);
        mapObjects.Add(mapObject);

        Vector3 cpPreviosPosition = startPosition;
        Vector3 cpNextPosition = new Vector3();
        float previosX = x, previosZ = z;

        for (int i = 0; i < routeSegments.Count; i++)
        {
            Vector3 cpPosition = routeSegments[i].ControlPoint.Position;

            //Draw circles
            x = cpPosition.x * scaleMap + offsetX;
            z = cpPosition.z * scaleMap + offsetZ;
            if (i == routeSegments.Count - 1 && Constants.FINISH_CONTROL_POINT_NAME.Equals(routeSegments[i].ControlPoint.name))
            {
                mapObject = Instantiate(finishMapObj, new Vector3(x, z, 0), Quaternion.identity) as Transform;
            }
            else
            {
                mapObject = Instantiate(controlPointMapObj, new Vector3(x, z, 0), Quaternion.identity) as Transform;
            }
            mapObject.SetParent(gameObject.transform);
            mapObjects.Add(mapObject);

            //Draw control points
            if (i > 0) { cpPreviosPosition = routeSegments[i - 1].ControlPoint.Position; }
            if (i != routeSegments.Count - 1) { cpNextPosition = routeSegments[i + 1].ControlPoint.Position; }

            float xNumber, zNumber, cNumber;
            if (i == 0)
            {
                xNumber = cpPosition.x - cpNextPosition.x;
                zNumber = cpPosition.z - cpNextPosition.z;
            }
            else if (i == routeSegments.Count - 1)
            {
                xNumber = cpPosition.x - cpPreviosPosition.x;
                zNumber = cpPosition.z - cpPreviosPosition.z;
            }
            else
            {
                xNumber = (cpPosition.x - cpPreviosPosition.x) + (cpPosition.x - cpNextPosition.x);
                zNumber = (cpPosition.z - cpPreviosPosition.z) + (cpPosition.z - cpNextPosition.z);
            }

            //Text
            if (!Constants.FINISH_CONTROL_POINT_NAME.Equals(routeSegments[i].ControlPoint.name))
            {
                cNumber = Mathf.Sqrt(xNumber * xNumber + zNumber * zNumber);

                Text numberkp = Instantiate(numberCPMapObj, new Vector3(x + dCircle * (xNumber / cNumber), z + dCircle * (zNumber / cNumber), 0), Quaternion.identity) as Text;
                numberkp.transform.SetParent(gameObject.transform);
                numberkp.text = routeSegments[i].ControlPoint.GetNumber();
            }

            //Draw lines
            float lengthX = x - previosX;
            float lengthZ = z - previosZ;
            float length = Mathf.Sqrt(lengthX * lengthX + lengthZ * lengthZ);
            if (length > dCircle)
            {
                Transform lineOnMap = Instantiate(lineMapObj, new Vector3(x - lengthX / 2, z - lengthZ / 2, 0), Quaternion.Euler(0, 0, (180 / Mathf.PI) * Mathf.Atan((lengthZ / lengthX)))) as Transform;
                lineOnMap.SetParent(gameObject.transform);
                lineOnMap.transform.localScale = new Vector3(length - dCircle, 1, 1);
            }
            previosX = x;
            previosZ = z;
        }
    }
}