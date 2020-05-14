using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using on scene
public class UIController : MonoBehaviour
{

    public GameObject mapPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mapPanel.SetActive(!mapPanel.activeSelf);
        }
    }
}
