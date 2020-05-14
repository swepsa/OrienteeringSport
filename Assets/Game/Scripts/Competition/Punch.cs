using System;

public class Punch
{
    public string NumberControlPoint { get; }
    public DateTime PunchesTime { get; }

    public Punch(string numberControlPoint, DateTime time)
    {
        NumberControlPoint = numberControlPoint;
        PunchesTime = time;
    }

    public override string ToString()
    {
        return NumberControlPoint + " - " + PunchesTime.ToString(Constants.FORMAT_TIME);
    }
}
