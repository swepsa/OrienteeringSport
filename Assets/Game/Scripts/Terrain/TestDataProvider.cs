using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class TestDataProvider : MapDataProvider
{
    protected override List<StartsPlace> CreateStartPlaces()
    {
        List<StartsPlace> startPlaces = new List<StartsPlace>
        {
            new StartsPlace(new Vector3(1f, 0f, 0f), new Vector3 (0, 45f, 0), new Vector3(1f, 5f, 0f), true),
            new StartsPlace(new Vector3(10f, 0f, 0f), new Vector3 (0, -45f, 0), new Vector3(10f, 5f, 0f), true)
        };
        return startPlaces;
    }

    protected override List<FinishPlace> CreateFinishPlaces()
    {
        List<FinishPlace> startPlaces = new List<FinishPlace>
        {
            null,
            new FinishPlace(new Vector3(11.39f, 0, 11.71f),new Vector3(0, 218.37f, 0), new ControlPoint(9.41f, 0.5f, 6.805639f, LAST_CONTROL_POINT_NAME))
        };
        return startPlaces;
    }

    protected override float InitMapScale()
    {
        return 50f;
    }

    protected override float[,] ControlPointsPositions => new float[,] {
        {2.65f, 0.6f, 8.63f},
        {9.13f, 0.6f, 8.63f},
        {9.13f, 0.6f, 2.5f},
        {2.65f, 0.6f, 2.5f},
        };
}