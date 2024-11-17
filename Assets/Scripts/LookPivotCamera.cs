using UnityEngine;

public class LookPivotCamera : MonoBehaviour
{

    public float sensX = 500f;
    public float sensY = 500f;

    public float smoothTime = 0.1f;

    //Private variables
    float xCurrent;
    float yCurrent;

    float xTarget;
    float yTarget;

    float xCurrentVelocity;
    float yCurrentVelocity;

    void Start()
    {
        // Initialize the current rotation and target values based on the current transform
        Vector3 currentRotation = transform.eulerAngles;
        xCurrent = currentRotation.y;
        yCurrent = currentRotation.x;
        xTarget = xCurrent;
        yTarget = yCurrent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Debug.Log("Middle mouse button held down.");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            Debug.Log($"Mouse Input - X: {mouseX}, Y: {mouseY}");
            
            xTarget += mouseX;
            yTarget -= mouseY;
        }
        else 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        transform.eulerAngles = new Vector3(yCurrent, xCurrent, 0f);
    }
}
