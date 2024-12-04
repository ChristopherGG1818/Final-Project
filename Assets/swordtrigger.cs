using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // For TextMeshPro

public class SwordTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapCounterText; // Reference to the UI TextMeshProUGUI component for tap count
    public int tapsRequired = 25;  // Number of taps needed to activate the sword
    public float tapTimeLimit = 1.5f; // Time limit to complete the taps
    private int tapCount = 0; // Track number of taps
    private float timer = 0f; // Timer to reset taps if the time limit is exceeded
    private bool isPlayerNear = false; // Flag to track if the player is near

    void Start()
    {
        // Ensure tap counter text is hidden initially
        if (tapCounterText != null)
        {
            tapCounterText.gameObject.SetActive(false);  // Hide the tap counter initially
        }
    }

    void Update()
    {
        if (isPlayerNear) // Only allow tapping when the player is near
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Tap detection (spacebar for simplicity)
            {
                tapCount++;
                timer = 0f; // Reset the timer on each valid tap

                // Update the tap count text on the UI
                UpdateTapCounterDisplay();

                if (tapCount >= tapsRequired)
                {
                    Debug.Log("Sword Activated!");
                    PerformSwordAction();
                    ResetTap(); // Reset tap count and timer after activation
                }
            }

            // Reset the tap count if the time exceeds the limit
            timer += Time.deltaTime;
            if (timer > tapTimeLimit)
            {
                ResetTap();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider belongs to the player
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (tapCounterText != null)
            {
                tapCounterText.gameObject.SetActive(true); // Show the tap counter when player is near
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the collider belongs to the player
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (tapCounterText != null)
            {
                tapCounterText.gameObject.SetActive(false); // Hide the tap counter when player leaves
            }
        }
    }

    // Update the tap counter display
    private void UpdateTapCounterDisplay()
    {
        if (tapCounterText != null)
        {
            tapCounterText.text = $"Taps: {tapCount}/{tapsRequired}";
        }
    }

    // Reset tap count and timer
    private void ResetTap()
    {
        tapCount = 0;
        timer = 0f;
        UpdateTapCounterDisplay();
    }

    // Perform the sword action (e.g., disable sword, trigger animation)
    private void PerformSwordAction()
    {
        Debug.Log("Sword action performed!");
        gameObject.SetActive(false);  // Example: Disabling the sword after activation
    }
}
