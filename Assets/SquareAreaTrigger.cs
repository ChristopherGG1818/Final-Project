using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // For TextMeshPro

public class SquareAreaTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText; // Reference to the UI TextMeshProUGUI component for the message
    private bool isPlayerNear = false; // Flag to track if the player is near

    void Start()
    {
        // Ensure the message text is hidden initially
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);  // Hide the message initially
        }
    }

    void Update()
    {
        if (isPlayerNear) // Only display the message when the player is near
        {
            // You can add any other functionality here, but no need for taps or timers
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider belongs to the player
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (messageText != null)
            {
                messageText.text = "Step on block: Tap C"; // Set the message to "Leave flowers"
                messageText.gameObject.SetActive(true); // Show the message when player is near
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the collider belongs to the player
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false); // Hide the message when player leaves
            }
        }
    }
}
