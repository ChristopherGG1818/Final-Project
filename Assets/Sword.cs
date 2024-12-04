using UnityEngine;

public class Sword : MonoBehaviour
{
    public string swordName = "This Sword"; // Name of the sword
    public int tapsRequired = 25;           // Number of taps needed to activate the action
    public float tapTimeLimit = 1.5f;      // Time limit to complete the taps
    public AudioSource audioSource;        // Reference to the AudioSource component
    public AudioClip activationSound;      // The sound to play when the sword is activated

    private int tapCount = 0;              // Tracks the number of taps
    private float timer = 0f;              // Timer to reset taps if limit is exceeded

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Get the AudioSource if not assigned in Inspector
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Example input for tapping
        {
            tapCount++;
            timer = 0f; // Reset the timer on each valid tap

            if (tapCount >= tapsRequired)
            {
                Debug.Log($"{swordName} activated!");
                PerformSwordAction();
                ResetTap(); // Reset tap count and timer after activation
                PlayActivationSound(); // Play the sound
                MakeSwordDisappear(); // Then disable the sword
            }
        }

        timer += Time.deltaTime;
        if (timer > tapTimeLimit)
        {
            ResetTap(); // Reset tap count if time limit is exceeded
        }
    }

    // Reset tap count and timer
    private void ResetTap()
    {
        tapCount = 0;
        timer = 0f;
    }

    private void PerformSwordAction()
    {
        // Add the specific action for the sword (e.g., animation, damage, etc.)
        Debug.Log($"{swordName} action performed!");
    }

    private void PlayActivationSound()
    {
        if (activationSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activationSound);
        }
        else
        {
            Debug.LogWarning("Activation sound or AudioSource is missing!");
        }
    }

    private void MakeSwordDisappear()
    {
        Debug.Log($"{swordName} has disappeared!");
        gameObject.SetActive(false);
    }
}
