using UnityEngine;

public class ControlPoint
{
    public string name;
    public Vector3 Position { get; }

    public ControlPoint(Vector3 position)
    {
        Position = position;
    }

    public ControlPoint(string name, Vector3 position)
    {
        this.name = name;
        Position = position;
    }

    public ControlPoint(float x, float y, float z, string name)
    {
        Position = new Vector3(x, y, z);
        this.name = name;
    }

    public string GetNumber()
    {
        if (name == null || name.Length > 2)
        {
            return name.Substring(2);
        }
        return name;
    }
}
