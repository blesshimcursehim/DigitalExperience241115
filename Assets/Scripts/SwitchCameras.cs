using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    // References to the camera controller objects
    public GameObject playerObject;  // PlayerObject from the FirstPersonCamera setup
    public GameObject cameraHolder;  // CameraHolder from the PivotCamera setup

    void Start()
    {
        // Set initial states: Activate only the PlayerObject for exploration
        playerObject.SetActive(true);
        cameraHolder.SetActive(false);
    }

    void Update()
    {
        // Listen for the tab key press to toggle between camera systems
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        // Check which camera is currently active
        bool isPlayerObjectActive = playerObject.activeSelf;

        // Switch the camera setup
        playerObject.SetActive(!isPlayerObjectActive);
        cameraHolder.SetActive(isPlayerObjectActive);

        // Lock or unlock the cursor depending on the active camera
        if (isPlayerObjectActive)
        {
            // Switching to PivotCamera
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Switching to FirstPersonCamera
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
