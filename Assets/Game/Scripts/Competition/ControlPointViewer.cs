using UnityEngine;

/*
 *use with children object with collider of control point 
 */
public class ControlPointViewer : MonoBehaviour
{
    public int textSize = 20;
    public Font textFont;
    public Color textColor = Color.white;
    public float textHeight = 1.15f;
    public bool showShadow = true;
    public Color shadowColor = new Color(0, 0, 0, 0.5f);
    public Vector2 shadowOffset = new Vector2(1, 1);

    void Awake()
    {
        enabled = false;
    }

    void OnGUI()
    {
        GUI.depth = 9999;

        GUIStyle style = new GUIStyle
        {
            fontSize = textSize,
            richText = true
        };
        if (textFont) style.font = textFont;
        style.normal.textColor = textColor;
        style.alignment = TextAnchor.MiddleCenter;

        GUIStyle shadow = new GUIStyle
        {
            fontSize = textSize,
            richText = true
        };
        if (textFont) shadow.font = textFont;
        shadow.normal.textColor = shadowColor;
        shadow.alignment = TextAnchor.MiddleCenter;

        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + textHeight, transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        screenPosition.y = Screen.height - screenPosition.y;

        string text = transform.parent.name.Substring(2);
        if (showShadow) GUI.Label(new Rect(screenPosition.x + shadowOffset.x, screenPosition.y + shadowOffset.y, 0, 0), text, shadow);
        GUI.Label(new Rect(screenPosition.x, screenPosition.y, 0, 0), text, style);
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Constants.PLAYER_TAG))
        { enabled = true; }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag(Constants.PLAYER_TAG))
        { enabled = false; }
    }
}