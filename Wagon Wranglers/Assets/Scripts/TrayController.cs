using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    // How fast the tray rotates when the players tries moving the tray
    [SerializeField] private float rotationSpeed = 0;

    // How fast the tray rotates when using the mouse in balance mode
    [SerializeField] public float mouseRotationSpeed = 100f;

    // When this is true it ignores the arrow keys and uses the mouse instead
    public bool useMouseControl = false;

    void Update()
    {
        float tiltX = 0f;
        float tiltZ = 0f;

        if (useMouseControl)
        {
            // Balance mode use mouse movement 
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Mouse Y tilts the tray forward/back
            tiltX = mouseY * mouseRotationSpeed * Time.deltaTime;

            // Mouse X tilts the tray left/right
            tiltZ = mouseX * mouseRotationSpeed * Time.deltaTime;
        }
        else
        {
            // Normal mode uses arrow keys
            float horizontal = Input.GetAxis("HorizontalArrow");
            float vertical = Input.GetAxis("VerticalArrow");

            tiltX = vertical * rotationSpeed * Time.deltaTime;
            tiltZ = horizontal * rotationSpeed * Time.deltaTime;
        }

        // Apply the rotation to the tray
        transform.Rotate(tiltX, 0f, tiltZ, Space.Self);
    }
}