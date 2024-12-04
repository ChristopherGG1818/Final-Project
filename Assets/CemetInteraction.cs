using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemetInteraction : MonoBehaviour
{
    [SerializeField] private AudioClip correctInteractionSound; // Audio for correct order
    [SerializeField] private AudioClip incorrectInteractionSound; // Audio for incorrect order
    [SerializeField] private AudioClip completionSound; // Audio for completion of all interactions
    private AudioSource audioSource;
    public int cemetOrder; // The activation order for this cemet
    public static int totalCemets = 6; // Total number of cemets in the sequence
    private static int currentCemet = 1; // Tracks the current step in the sequence
    private bool isPlayerNear = false; // Tracks if the player is near the cemet
    private static bool taskCompleted = false; // Flag for when the task is completed

    [SerializeField] private GameObject Shield; // Reference to the shield GameObject

    void Start()
    {
        // Add an AudioSource component if one doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the shield is hidden at the start
        if (Shield != null)
        {
            Shield.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F) && !taskCompleted)
        {
            if (cemetOrder == currentCemet) // Correct order
            {
                Debug.Log($"Cemet {cemetOrder} activated.");
                PlaySound(correctInteractionSound); // Play correct sound
                currentCemet++; // Advance to the next cemet

                if (currentCemet > totalCemets) // All cemets interacted with correctly
                {
                    taskCompleted = true; // Mark task as completed
                    PlaySound(completionSound); // Play completion sound
                    Debug.Log("All cemets activated in order. Task complete!");

                    // Show the shield after the puzzle is completed
                    if (Shield != null)
                    {
                        Shield.SetActive(true);
                    }
                }
            }
            else
            {
                Debug.Log("Incorrect cemet. Try the correct one!");
                PlaySound(incorrectInteractionSound); // Play incorrect sound
                ResetPuzzle();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioClip or AudioSource is missing!");
        }
    }

    private void ResetPuzzle()
    {
        currentCemet = 1; // Reset the sequence to the first cemet
        taskCompleted = false; // Reset task completion
        Debug.Log("Puzzle reset. Starting from the first cemet.");
    }
}
