using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour
{
    [SerializeField] private AudioClip correctInteractionSound; // Audio for correct order
    [SerializeField] private AudioClip incorrectInteractionSound; // Audio for incorrect order
    [SerializeField] private AudioClip completionSound; // Audio for completion of all interactions
    private AudioSource audioSource;

    public int blockOrder; // The activation order for this block
    public static int totalBlocks = 4; // Total number of blocks in the sequence
    private static int currentBlock = 1; // Tracks the current step in the sequence
    private bool isPlayerNear = false; // Tracks if the player is near the block
    private static bool taskCompleted = false; // Flag for when the task is completed

    [SerializeField] private GameObject helmet; // Reference to the helmet GameObject
    [SerializeField] private GameObject armor; // Reference to the armor GameObject
    [SerializeField] private GameObject arms; // Reference to the arms GameObject
    [SerializeField] private GameObject boots; // Reference to the boots GameObject

    void Start()
    {
        // Add an AudioSource component if one doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the items are hidden at the start
        if (helmet != null) helmet.SetActive(false);
        if (armor != null) armor.SetActive(false);
        if (arms != null) arms.SetActive(false);
        if (boots != null) boots.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.C) && !taskCompleted)
        {
            if (blockOrder == currentBlock) // Correct order
            {
                Debug.Log($"Block {blockOrder} activated.");
                PlaySound(correctInteractionSound); // Play correct sound
                currentBlock++; // Advance to the next block

                if (currentBlock > totalBlocks) // All blocks interacted with correctly
                {
                    taskCompleted = true; // Mark task as completed
                    PlaySound(completionSound); // Play completion sound
                    Debug.Log("All blocks activated in order. Task complete!");

                    // Show the items after the puzzle is completed
                    ShowItems();
                }
            }
            else
            {
                Debug.Log($"Incorrect block {blockOrder}. Resetting puzzle.");
                PlaySound(incorrectInteractionSound); // Play incorrect sound
                ResetPuzzle();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = true; // Player has entered the trigger area
            Debug.Log($"Player is near block {blockOrder}");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false; // Player has left the trigger area
            Debug.Log($"Player left block {blockOrder}'s area.");
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

    private void ShowItems()
    {
        // Show the items after the puzzle is completed
        if (helmet != null) helmet.SetActive(true);
        if (armor != null) armor.SetActive(true);
        if (arms != null) arms.SetActive(true);
        if (boots != null) boots.SetActive(true);
    }

    private void ResetPuzzle()
    {
        currentBlock = 1; // Reset the sequence to the first block
        taskCompleted = false; // Reset task completion
        Debug.Log("Puzzle reset. Starting from the first block.");
    }
}
