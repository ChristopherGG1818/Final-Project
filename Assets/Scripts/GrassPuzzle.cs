using UnityEngine;

public class GrassPuzzle : MonoBehaviour
{
    public GameObject[] grassTiles; // Assign tiles in the Inspector
    public int[] correctOrder; // Correct sequence of tile indices
    private int[] playerOrder;
    private int currentStep;

    public AudioSource audioSource; // Audio source for playing sounds
    public AudioClip activationSound; // Sound for correct or activated steps
    public AudioClip incorrectSound; // Sound for incorrect steps

    void Start()
    {
        playerOrder = new int[correctOrder.Length];
        currentStep = 0;

        // Ensure the AudioSource is attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Method called when the player steps on a grass tile
    public void OnGrassStepped(int tileIndex)
    {
        if (currentStep >= correctOrder.Length)
            return;

        playerOrder[currentStep] = tileIndex;

        if (playerOrder[currentStep] != correctOrder[currentStep])
        {
            Debug.Log("Incorrect sequence. Resetting puzzle.");
            PlaySound(incorrectSound); // Play incorrect sound
            ResetPuzzle();
            return;
        }

        PlaySound(activationSound); // Play activation sound for correct step
        currentStep++;

        if (currentStep == correctOrder.Length)
        {
            Debug.Log("Puzzle solved!");
            OnPuzzleComplete();
        }
    }

    // Reset puzzle if the sequence is incorrect
    private void ResetPuzzle()
    {
        currentStep = 0;
        // Optional: Add reset effects
    }

    // Handle puzzle completion logic
    private void OnPuzzleComplete()
    {
        Debug.Log("Puzzle Complete!");
        // Add puzzle completion logic here
    }

    // Play sound for the provided audio clip
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Play the sound once
        }
    }

    // Play the activation sound when the player enters a tile area
    public void PlayActivationSound()
    {
        if (activationSound != null)
        {
            audioSource.PlayOneShot(activationSound); // Play the activation sound once
        }
    }
}
