using UnityEngine;

public class StartsPlace
{
    public Vector3 Position { get; }
    public Vector3 Rotation { get; }
    public Vector3 PlayerStartPosition { get; }
    public bool ForwardDirection { get; }

    public StartsPlace(Vector3 position, Vector3 rotation, Vector3 playerStartPosition, bool forwardDirection)
    {
        Position = position;
        Rotation = rotation;
        PlayerStartPosition = playerStartPosition;
        ForwardDirection = forwardDirection;
    }
}