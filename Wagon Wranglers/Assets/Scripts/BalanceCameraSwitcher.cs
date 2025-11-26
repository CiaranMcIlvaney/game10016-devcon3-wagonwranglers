using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCameraSwitcher : MonoBehaviour
{
    // A public static reference so any script can access it
    public static BalanceCameraSwitcher Instance;

    [SerializeField] private Camera playerCam; // The 3rd person player camera
    [SerializeField] private Camera balanceCam; // The "cinematic" camera when balancing an item

    // This will be for disabling player movement + mouse movement during the balancing camera
    [SerializeField] private MonoBehaviour[] disabledScripts;
    
    // This helps us make sure we dont turn balance mode on twice
    private bool inBalanceMode = false;

    private void Awake()
    {
        // Makes this script the main instance so that other scripts (ItemLifetime) can call BalanceCameraSwitcher.Instance.EnterBalanceMode()
        // or BalanceCameraSwitcher.Instance.ExitBalanceMode()
        Instance = this;
    }

    public void EnterBalanceMode()
    {
        // If we are already in balance mode then dont do anything
        if (inBalanceMode)
        {
            return;
        }
        inBalanceMode = true;
     
        // Turn off the normal player camera
        playerCam.enabled = false;

        // Turn on the balance camera so the players can see the tray better
        balanceCam.enabled = true;

        // Disable all the scripts that let the player move or look around, making so player only focus on balancing
        foreach (var script in disabledScripts)
        {
            script.enabled = false;
        }
    }

    public void ExitBalanceMode()
    {
        inBalanceMode = false;

        // Turn normal player camera back on
        playerCam.enabled = true;

        // Turn off the balance camera
        balanceCam.enabled = false;

        // Enable al the scripts that let the player move or look around, so they can try and catch more stuff
        foreach (var script in disabledScripts)
        {
          script.enabled = true;
        }
    }
}