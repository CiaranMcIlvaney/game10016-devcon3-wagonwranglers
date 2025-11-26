using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceModeController : MonoBehaviour
{
    public static BalanceModeController Instance { get; private set; }

    [Header("References")]
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform tray;
    [SerializeField] private MonoBehaviour playerMovement;

    [Header("Balance Camera Settings")]
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 5f, -4f);

    [SerializeField] private bool lockPlayerInBalanceMode = true;

    private bool inBalanceMode = false;

    private void Awake()
    {
        Instance = this;
    }

    public void EnterBalanceMode()
    {
        if (inBalanceMode) return;
        inBalanceMode = true;

        // Disable movement so the player can focus on balancing
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Snap camera into cinematic view
        mainCamera.position = tray.position + cameraOffset;
        mainCamera.LookAt(tray.position);
    }

    public void ExitBalanceMode()
    {
        inBalanceMode = false;

        if (playerMovement != null)
            playerMovement.enabled = true;
    }
}
