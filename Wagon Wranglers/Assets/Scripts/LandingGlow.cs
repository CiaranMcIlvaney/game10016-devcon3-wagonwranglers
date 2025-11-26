using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGlow : MonoBehaviour
{
    // The glowy prfab that will appear on the floor
    [SerializeField] private GameObject glowPrefab; 
    
    // How high above the floor the glow will sit, this stops it from z fighting the ground
    [SerializeField] private float glowYOffset = 0.05f; 

    // How long the glow stays on the floor before it dissapears 
    [SerializeField] private float glowDuration = 3f;  

    private void Start()
    {
        // Shoot a raycast down from the objects spawn position
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 100f))
        {
            // Take the raycast hit point and then move it up with the glowYOffset
            Vector3 glowPos = hit.point + Vector3.up * glowYOffset;

            // Rotate the glow so it lies flat on the ground
            Quaternion glowRotation = Quaternion.Euler(90f, 0f, 0f);

            // Actually spawn the flow after object on the floor
            GameObject glowInstance = Instantiate(glowPrefab, glowPos, glowRotation);

            // Delete the glow after the amount of time that glowDuration is
            Destroy(glowInstance, glowDuration);
        }
    }
}
