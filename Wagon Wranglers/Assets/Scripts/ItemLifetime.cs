using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifetime : MonoBehaviour
{
    // How long the item needs to stay on the tray to be counted as collected
    [SerializeField] private float balanceTime = 5f;

    // Timer that will count up only when the item is on the tray
    private float balanceTimer = 0f;

    // Only becomes true when an item is on the tray
    private bool itemOnTray = false;

    // How many points this item will give to the player if collected
    [SerializeField] private int pointsValue = 10; 

    // Reference to this items rigidbody
    private Rigidbody rb;

    private void Start()
    {
        // Grab the rigidbody when the item spawns
        rb = GetComponent<Rigidbody>();
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

                // Switch camera back to normal after scoring
                BalanceCameraSwitcher.Instance.ExitBalanceMode();

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
            // Switch camera back to normal if item dropped
            BalanceCameraSwitcher.Instance.ExitBalanceMode();

            Destroy(gameObject);
        }

        // If an item touches the tray than start the balancing timer
        if (collision.collider.CompareTag("Tray"))
        {
            itemOnTray = true;

            // Turn on special balance camera view
            BalanceCameraSwitcher.Instance.EnterBalanceMode();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the item falls off the tray then stop counting and reset the timer to 0
        if (collision.collider.CompareTag("Tray"))
        {
            itemOnTray = false;
            balanceTimer = 0f;

            // Back to normal camera if it falls off
            BalanceCameraSwitcher.Instance.ExitBalanceMode();
        }
    }
}
