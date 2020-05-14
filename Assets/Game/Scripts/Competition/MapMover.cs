using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Using with MapPicture on scene
public class MapMover : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform scaleLine;
    public Text text;

    private MapController mapController;
    private List<Transform> mapObjects;
    private Vector2 transformDelta;
    private int currentPos = 0;
    private float scaleMap;

    void Awake()
    {
        mapController = GetComponent<MapController>();
        mapObjects = mapController.mapObjects;    
    }

    void Start()
    {
        scaleMap = mapController.ScaleMap;
        scaleLine.localScale = new Vector3(transform.localScale.x * scaleMap, 1, 1);
        if (scaleMap > 0 && scaleMap < float.MaxValue)
        {
            text.text = "1 m";
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && currentPos < mapObjects.Count - 2)
        {
            currentPos++;
            MoveMap();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentPos > 0)
        {
            currentPos--;
            MoveMap();
        }
    }

    void LateUpdate()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            if (transform.localScale.x > 1f && scroll < 0 || transform.localScale.x < 2.0f && scroll > 0)
            {
                transform.localScale += new Vector3(1, 1, 0) * scroll;
                scaleLine.localScale = new Vector3(transform.localScale.x * scaleMap, 1, 1);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transformDelta = eventData.pointerCurrentRaycast.screenPosition - (Vector2)transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(1))
        { transform.position = eventData.pointerCurrentRaycast.screenPosition - transformDelta; }
        else if (Input.GetMouseButton(0))
        {
            float axis = Input.GetAxis("Mouse X");
            if (axis != 0) { transform.parent.Rotate(Vector3.forward, -axis); }
            else
            {
                axis = Input.GetAxis("Mouse Y");
                if (axis != 0)
                {
                    transform.parent.Rotate(Vector3.forward, axis);
                }
            }
        }
    }

    private void MoveMap()
    {
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        gameObject.transform.localPosition = -mapObjects[currentPos].localPosition * gameObject.transform.localScale.x;
        float v = Mathf.Rad2Deg * Mathf.Atan2((mapObjects[currentPos + 1].position.y - mapObjects[currentPos].position.y), (mapObjects[currentPos + 1].position.x - mapObjects[currentPos].position.x));
        gameObject.transform.RotateAround(mapObjects[currentPos].position, Vector3.forward, 90 - v);
    }
}