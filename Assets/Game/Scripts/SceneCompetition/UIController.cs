using UnityEngine;

//using on scene
public class UIController : MonoBehaviour
{

    public GameObject mapPanel;
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find(Constants.PLAYER).transform.Find("shadow").gameObject;
    }

    void Start()
    {
        mapPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mapPanel.SetActive(!mapPanel.activeSelf);
            player.SetActive(!player.activeSelf);
        }
    }
}