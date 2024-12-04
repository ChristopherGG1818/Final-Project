using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] private GameObject shield; // Reference to the shield GameObject
    private bool isPlayerNear = false; // Track if the player is near the shield

    void Start()
    {
        // Ensure the shield is visible at the start or can be controlled accordingly
        if (shield != null)
        {
            shield.SetActive(true); // Shield starts visible, modify if needed
        }
    }

    void Update()
    {
        // If the player is near and presses a key (for example, 'E'), the shield disappears
        if (isPlayerNear && Input.GetKeyDown(KeyCode.B))
        {
            if (shield != null)
            {
                shield.SetActive(false); // Hide the shield when player interacts
                Debug.Log("Weapons disappeared.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = true; // Player has entered the trigger area
            Debug.Log("Player is near the weapons.");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerNear = false; // Player has left the trigger area
            Debug.Log("Player left the weapons area.");
        }
    }
}
