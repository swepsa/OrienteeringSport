using UnityEngine;

//using with object Compass
public class Compass : MonoBehaviour
{
    private Transform arrow;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find(Constants.PLAYER).transform.Find("Main Camera");
        arrow = transform.Find("Arrow");
    }

    private void Update()
    {
        arrow.localRotation = Quaternion.Euler(0, 0, 360 - mainCamera.rotation.eulerAngles.y);
    }
}