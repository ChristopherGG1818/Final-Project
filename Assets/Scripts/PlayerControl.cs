using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour, IShopCustomer
{
    private float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public int money;

    public int health;

    Vector2 velocity;

    public AudioSource audioSource;
    public AudioClip[] musicClips; // Array of music tracks
    private int currentTrack = 0;

    void Update()
    {
        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",velocity.x);
        animator.SetFloat("Vertical",velocity.y);
        animator.SetFloat("Speed", velocity.sqrMagnitude);
        //Debug.Log(velocity);

        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity.normalized * moveSpeed * Time.fixedDeltaTime);
        
    }

    void PlayTrack(int index)
    {
        audioSource.clip = musicClips[index];
        audioSource.Play();
    }

    void NextTrack()
    {
        currentTrack = (currentTrack + 1) % musicClips.Length; // Loop back to start
        PlayTrack(currentTrack);
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought Item: " + itemType);
    }

// Monetary system in which makes the player return a type of currency.
    public int getMoney() {
        return money;
    }

//System in which makes the player return an amount of health.
    public int getHealth() {
        return health;
    }

    public bool tryToBuy(int cost)
    {
        if (money >= cost) {
            money = money - cost;
            return true;
        } else {
            return false;
        }
    }
}
