using UnityEngine;
using System.Collections;

public class StrategyGameCamera : MonoBehaviour
{

    [Range(0.1f, 20)]
    public float cameraSpeed;

    public float minHeight;
    public float maxHeight;

    public float zoomSpeed;


    public struct MouseScrollLimits
    {
        public float RightBorder;
        public float LeftBorder;
        public float UpBorder;
        public float DownBorder;
    }
    public static MouseScrollLimits ScrollLimits;



    // Use this for initialization
    void Start()
    {
        ScrollLimits = new MouseScrollLimits();
        ScrollLimits.RightBorder = 40;
        ScrollLimits.LeftBorder = 40;
        ScrollLimits.UpBorder = 40;
        ScrollLimits.DownBorder = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if (AreCameraButtonsPressed() || IsMouseOutBorders())
        {
            Vector3 translation = GetDesiredTranslation();
            this.transform.Translate(translation, Space.World);
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            if ((Input.mouseScrollDelta.y < 0 && this.transform.position.y < maxHeight) ||
                ((Input.mouseScrollDelta.y > 0 && this.transform.position.y > minHeight))) // Min and Max Zoom.
                this.transform.Translate(new Vector3(0, 0, Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime)); //Translates relative to the camera. For zooming in.
        }
    }

    public Vector3 GetDesiredTranslation()
    {
        Vector3 tr = new Vector3(0, 0, 0);
        Vector3 m = Input.mousePosition;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || (m.x < ScrollLimits.LeftBorder && m.x > -20))
            tr.x -= 1.0f;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || (m.x > (Screen.width - ScrollLimits.RightBorder) && m.x < (Screen.width + 20)))
            tr.x += 1.0f;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || (m.y > (Screen.height - ScrollLimits.UpBorder) && m.y > -20))
            tr.z += 1.0f;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || (m.y < ScrollLimits.DownBorder && m.y > -20))
            tr.z -= 1.0f;

        tr *= Time.deltaTime;
        tr *= cameraSpeed;

        tr *= this.transform.position.y; //The more high we are (...), the more the speed is.
        return tr;
    }


    public static bool AreCameraButtonsPressed()
    {
        return (Input.GetKey(KeyCode.Z) ||
            Input.GetKey(KeyCode.Q) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow));
    }
    public static bool IsMouseOutBorders()
    {
        Vector3 m = Input.mousePosition;
        //Input.mouseScrollDelta;

        return (
            m.x < ScrollLimits.LeftBorder && m.x > -20 ||
            m.x > (Screen.width - ScrollLimits.RightBorder) && m.x < (Screen.width + 20) ||
            m.y < ScrollLimits.DownBorder && m.y > -20 ||
            m.y > (Screen.height - ScrollLimits.UpBorder) && m.y < (Screen.height + 20));
    }
}