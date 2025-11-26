using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // A public static reference so any script can access it
    public static ScoreManager Instance { get; private set; }

    // The text on the UI that shows the player's score
    [SerializeField] private TextMeshProUGUI scoreText; 

    // This keeps track of how many points the player currently has
    private int currentScore = 0;

    private void Awake()
    {
        // Makes this script the main instance so that other scripts (ItemLifetime) can call ScoreManager.Instance.AddScore()
        Instance = this;
    }

    // This gets called whenever the player earns points
    public void AddScore(int amount)
    {
        currentScore += amount; // Adds points to the total
        UpdateScoreUI(); // Update the UI text so the player sees the change
    }

    // Updates the text on screen to match the current score
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
