using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float zoomSpeed = 100f;
    public float minFOV = 60f;
    public float maxFOV = 90f;


    private bool cameraMovement = true;


    void Update()
    {

        if (Input.GetKey(KeyCode.V))
            cameraMovement = !cameraMovement;

        if (transform.position.y <= minFOV && Input.mouseScrollDelta.y < 0 )
            transform.Translate(zoomSpeed * Time.deltaTime * -Input.mouseScrollDelta * Vector3.up, Space.World);

        if (transform.position.y >= maxFOV && Input.mouseScrollDelta.y > 0)
            transform.Translate(zoomSpeed * Time.deltaTime * -Input.mouseScrollDelta * Vector3.up, Space.World);

        if (transform.position.y <= maxFOV && transform.position.y >= minFOV)
            transform.Translate(zoomSpeed * Time.deltaTime * -Input.mouseScrollDelta * Vector3.up, Space.World);

        if (!cameraMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(panSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(panSpeed * Time.deltaTime * Vector3.back, Space.World);
        

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(panSpeed * Time.deltaTime * Vector3.right, Space.World);

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(panSpeed * Time.deltaTime * Vector3.left, Space.World);

    }
}
