using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class RedGrave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText; // Reference to the UI TextMeshProUGUI component for the message
    [SerializeField] private AudioClip keyOne; // Audio clip for interaction
    private AudioSource audioSource; // Reference to AudioSource component
    private bool isPlayerNear = false; // Flag to track if the player is near the RedGrave

    void Start()
    {
        // Ensure the message text is hidden initially
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Hide the message initially
        }

        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the player is near and presses "R"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("You left flowers at the Red Grave."); // Perform the action
            PlayInteractionSound(); // Play audio
            HideMessage(); // Hide the message after the interaction
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
                messageText.text = "Press R to leave flowers"; // Display the interaction message
                messageText.fontSize = 36; // Adjust the font size if needed
                messageText.gameObject.SetActive(true); // Show the message
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the collider belongs to the player
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false;
            HideMessage(); // Hide the message when the player leaves
        }
    }

    // Play the interaction sound
    private void PlayInteractionSound()
    {
        if (keyOne != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyOne);
        }
        else
        {
            Debug.LogWarning("KeyOne audio clip or AudioSource is missing!");
        }
    }

    // Hide the interaction message
    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
