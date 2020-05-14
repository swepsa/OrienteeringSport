using System.Collections.Generic;

public class Route
{
    public List<RouteSegment> RouteSegments { get; }
    public float LenghtRoute { get; private set; }

    public Route()
    {
        RouteSegments = new List<RouteSegment>();
    }

    public void AddRouteSegment(RouteSegment routeSegment)
    {
        RouteSegments.Add(routeSegment);
        LenghtRoute += routeSegment.DistanceFromPreviousControlPoint;
    }

    public void RemoveLastSegment()
    {
        RouteSegment lastSegment = RouteSegments[RouteSegments.Count - 1];
        LenghtRoute -= lastSegment.DistanceFromPreviousControlPoint;
        RouteSegments.Remove(lastSegment);
    }

    public ControlPoint GetLastControlPoint()
    {
        if (RouteSegments == null || RouteSegments.Count == 0) { return null; }
        return RouteSegments[RouteSegments.Count - 1].ControlPoint;
    }
}