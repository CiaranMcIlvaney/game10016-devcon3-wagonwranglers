using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifetime : MonoBehaviour
{
    // How long the item needs to stay on the tray to be counted as collected
    [SerializeField] private float balanceTime = 5f;

    // Timer that will count up only when the item is on the tray
    private float balanceTimer = 0f;

    // Only becomes true when THIS item is currently touching the tray
    private bool itemOnTray = false;

    // How many points this item will give to the player if collected
    [SerializeField] private int pointsValue = 10;

    // Reference to this items rigidbody
    private Rigidbody rb;

    private CharacterMove characterMove;
    private Eyeballs eyeballs;
    private TrayController trayController;

    // Tracks how many items TOTAL are currently balancing on the tray
    private static int activeBalancingItems = 0;

    private void Start()
    {
        // Grab the rigidbody when the item spawns
        rb = GetComponent<Rigidbody>();

        characterMove = FindObjectOfType<CharacterMove>();
        eyeballs = FindObjectOfType<Eyeballs>();
        trayController = FindObjectOfType<TrayController>();
    }

    private void Update()
    {
        // If the item is on the tray then start counting the time
        if (itemOnTray)
        {
            // Add time from each frame to the balanceTimer
            balanceTimer += Time.deltaTime;

            // If the player balanced the item long enough on the tray
            if (balanceTimer >= balanceTime)
            {
                // Give the player points
                ScoreManager.Instance.AddScore(pointsValue);

                // This item is done balancing, clean up balance state
                StopBalancing();

                // Destroy the object since its been collected
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If an item hits the floor then instantly delete it
        if (collision.collider.CompareTag("Floor"))
        {
            // If it was currently balancing, clean that up first
            StopBalancing();
            Destroy(gameObject);
            return;
        }

        // If an item touches the tray then start the balancing timer
        if (collision.collider.CompareTag("Tray"))
        {
            StartBalancing();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the item falls off the tray then stop counting and reset the timer to 0
        if (collision.collider.CompareTag("Tray"))
        {
            StopBalancing();
        }
    }

    private void OnDestroy()
    {
        // If this gets destroyed while still marked as on the tray make sure to not leave the game stuck in balance mode
        StopBalancing();
    }

    private void StartBalancing()
    {
        // If already registered as balancing do nothing
        if (itemOnTray)
        {
            return;
        }

        itemOnTray = true;
        balanceTimer = 0f;

        // Increase the global count
        activeBalancingItems++;

        // If this is the first item to start balancing freeze the player and enable mouse tray control
        if (activeBalancingItems == 1)
        {
            characterMove.isFrozen = true;
            eyeballs.isFrozen = true;
            trayController.useMouseControl = true;
        }
    }

    private void StopBalancing()
    {
        itemOnTray = false;
        balanceTimer = 0f;

        // Reduce global count but never let it go below zero
        activeBalancingItems = Mathf.Max(0, activeBalancingItems - 1);

        // If there are no more items being balanced unfreeze and leave mouse mode
        if (activeBalancingItems == 0)
        {
            characterMove.isFrozen = false;
            eyeballs.isFrozen = false;
            trayController.useMouseControl = false;
        }
    }
}
