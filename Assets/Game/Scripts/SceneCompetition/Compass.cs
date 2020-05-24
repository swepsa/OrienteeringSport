using UnityEngine;

//using with object Compass
public class Compass : MonoBehaviour
{
    private Transform arrow;
    private Transform capsule;
    private Transform map;
    private Transform mapPicture;
    private Transform mainCamera;
    private const int SPEED = 100;

    private void Awake()
    {
        mainCamera = GameObject.Find(Constants.PLAYER).transform.Find("Main Camera");
        arrow = transform.Find("Arrow");
        capsule = transform.Find("Capsule");
        map = transform.parent.Find("Map");
        mapPicture = map.transform.GetChild(0);
    }

    private void Update()
    {
        arrow.localRotation = Quaternion.RotateTowards(arrow.localRotation, Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.y), SPEED * Time.deltaTime);
        Vector3 angle = map.localRotation.eulerAngles + mapPicture.localRotation.eulerAngles;
        capsule.localRotation = Quaternion.RotateTowards(capsule.localRotation, Quaternion.Euler(angle), SPEED * Time.deltaTime);
    }
}