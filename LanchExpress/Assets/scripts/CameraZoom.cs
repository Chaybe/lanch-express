using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomFOV = 50f;
    public float normalFOV = 60f;
    public float zoomSpeed = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = normalFOV;
    }

    void Update()
    {
        bool isPressingArrow = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        float targetFOV = isPressingArrow ? zoomFOV : normalFOV;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }
}
