public class RouteSegment
{
    public ControlPoint ControlPoint { get; }
    public float DistanceFromPreviousControlPoint { get; }

    public RouteSegment(ControlPoint controlPoint, float distanceFromPreviousControlPoint)
    {
        ControlPoint = controlPoint;
        DistanceFromPreviousControlPoint = distanceFromPreviousControlPoint;
    }
}