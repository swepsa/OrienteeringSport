using UnityEngine;

public class FinishPlace
{
    public Vector3 position;
    public Vector3 rotation;
    public ControlPoint positionCP100;

    public FinishPlace(Vector3 position, Vector3 rotation, ControlPoint positionCP100)
    {
        this.position = position;
        this.rotation = rotation;
        this.positionCP100 = positionCP100;
    }
}
