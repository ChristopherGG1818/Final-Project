using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSequence : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource to play sounds
    public AudioClip[] objectSounds; // Sounds for each object (7 in total)
    public AudioClip correctSound;  // Sound to play when the sequence is correct
    public AudioClip incorrectSound; // Sound to play when the sequence is incorrect
    
    private int correctOrderIndex = 0; // Tracks the player's progress in the correct order
    private bool isPlayerNear = false; // Check if player is near the object

    private KeyCode[] correctKeySequence = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7 }; // Correct key sequence for 1 to 7
    private List<KeyCode> playerInputSequence = new List<KeyCode>(); // Stores the player's key presses

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Ensure AudioSource is assigned
        }
    }

    void Update()
    {
        // Only process input if the player is near the object
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                ProcessInput(KeyCode.Alpha1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                ProcessInput(KeyCode.Alpha2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                ProcessInput(KeyCode.Alpha3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)) {
                ProcessInput(KeyCode.Alpha4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5)) {
                ProcessInput(KeyCode.Alpha5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6)) {
                ProcessInput(KeyCode.Alpha6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7)) {
                ProcessInput(KeyCode.Alpha7);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    // Method to handle key presses
    void ProcessInput(KeyCode key)
    {
        playerInputSequence.Add(key); // Store the player's input

        // Play the corresponding sound for the key pressed
        int index = System.Array.IndexOf(correctKeySequence, key);
        if (index >= 0 && index < objectSounds.Length)
        {
            audioSource.PlayOneShot(objectSounds[index]);
        }

        // Check if the player pressed the keys in the correct order
        if (playerInputSequence.Count == correctOrderIndex + 1)
        {
            if (key == correctKeySequence[correctOrderIndex])
            {
                Debug.Log("Correct Key!");

                // If the sequence is correct, play a success sound
                if (correctOrderIndex == correctKeySequence.Length - 1)
                {
                    audioSource.PlayOneShot(correctSound); // Play correct sequence sound
                    Debug.Log("Correct sequence completed!");
                    ResetSequence(); // Reset the sequence after success
                }
                else
                {
                    correctOrderIndex++; // Move to the next step in the sequence
                }
            }
            else
            {
                Debug.Log("Incorrect Key!");
                audioSource.PlayOneShot(incorrectSound); // Play incorrect sequence sound
                ResetSequence(); // Reset the sequence after incorrect input
            }
        }
    }

    // Method to reset the sequence and clear the player input
    void ResetSequence()
    {
        correctOrderIndex = 0;
        playerInputSequence.Clear();
        Debug.Log("Sequence reset.");
    }
}
