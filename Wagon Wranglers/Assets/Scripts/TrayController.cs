using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    // How fast the tray rotates when the players tries moving the tray
    [SerializeField] private float rotationSpeed = 0;

    void Update()
    {
        // Get input from the custom Input Manager axes I made, where horizontal arrow only tracks the arrow key movments
        // And regular Horizontal and Vertical axes only now track wasd
        float horizontal = Input.GetAxis("HorizontalArrow");
        float vertical = Input.GetAxis("VerticalArrow");
        
        // Converts the vertical input into tilt around the x-axis
        float tiltX = vertical * rotationSpeed * Time.deltaTime;

        //  Converts the horizontal input into tilt around the z-axis
        float tiltZ = horizontal * rotationSpeed * Time.deltaTime;

        // Applies the rotation to the tray
        // Space.Self makes the rotation apply to the trays own axis
        transform.Rotate(tiltX, 0f, tiltZ, Space.Self);
    }
}
