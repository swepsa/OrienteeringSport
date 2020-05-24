using System.Collections.Generic;
using UnityEngine;

//dont use in any scenes
public abstract class MapDataProvider : MonoBehaviour
{
    public MapDataProvider()
    {
        InitStartPlaces();
        InitControlPoints();
        InitFinishPlaces();
        MapScale = InitMapScale();
    }

    public List<StartsPlace> StartPlaces { get; private set; }
    public List<ControlPoint> ControlPoints { get; private set; }
    public List<FinishPlace> FinishPlaces { get; private set; }
    public float MapScale { get; private set; }

    public abstract SkyBoxData SkyBoxDataDay();
    public abstract SkyBoxData SkyBoxDataNight();

    private void InitStartPlaces()
    {
        StartPlaces = CreateStartPlaces();
    }

    private void InitControlPoints()
    {
        ControlPoints = new List<ControlPoint>();

        float[,] positions = ControlPointsPositions;

        for (int i = 0; i < positions.GetLength(0); i++)
        {
            Vector3 position = new Vector3(positions[i, 0], positions[i, 1], positions[i, 2]);
            ControlPoints.Add(new ControlPoint(position));
        }
    }

    // each finish match start, if you don't use finish, then use null object.
    // count of finish equals count of starts
    private void InitFinishPlaces()
    {
        FinishPlaces = CreateFinishPlaces();
    }

    protected abstract List<StartsPlace> CreateStartPlaces();

    protected abstract float[,] ControlPointsPositions { get; }

    protected abstract List<FinishPlace> CreateFinishPlaces();

    protected abstract float InitMapScale();
}