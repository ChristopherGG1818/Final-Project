// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Game_Assets : MonoBehaviour
// {
//     private static Game_Assets i;

//     // Singleton to access Game_Assets globally
//     public static Game_Assets instance {
//         get {
//             if (i == null) {
//                 // Load the GameAssets prefab from Resources and instantiate it
//                 GameObject gameAssets = Resources.Load<GameObject>("GameAssets");
//                 if (gameAssets != null) {
//                     i = Instantiate(gameAssets).GetComponent<Game_Assets>();
//                 } else {
//                     Debug.LogError("GameAssets prefab not found in Resources folder.");
//                 }
//             }
//             return i;
//         }
//     }

//     // List of audio tracks
//     public List<AudioClip> musicTracks; 
//     private AudioSource audioSource; // The AudioSource component for playing music
//     private int currentTrackIndex = 0; // Index to keep track of the current music track

//     void Awake()
//     {
//         // Initialize the audio source if not already done
//         if (audioSource == null)
//         {
//             audioSource = gameObject.AddComponent<AudioSource>();
//             audioSource.loop = false; // Let tracks end naturally
//             audioSource.volume = 0.5f; // Set initial volume
//         }
//     }

//     void Start()
//     {
//         // Start playing music if there are tracks available
//         if (musicTracks != null && musicTracks.Count > 0)
//         {
//             PlayCurrentTrack();
//         }
//     }

//     void Update()
//     {
//         // If the current track has finished playing, move to the next one
//         if (!audioSource.isPlaying && musicTracks.Count > 0)
//         {
//             PlayNextTrack();
//         }
//     }

//     private void PlayCurrentTrack()
//     {
//         // Check if there are tracks available
//         if (musicTracks.Count > 0)
//         {
//             audioSource.clip = musicTracks[currentTrackIndex]; // Set the current track
//             audioSource.Play(); // Play the current track
//         }
//     }

//     private void PlayNextTrack()
//     {
//         // Advance to the next track
//         currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Count; // Loop back to the first track
//         PlayCurrentTrack(); // Play the next track
//     }

//     // Method to set the volume of the music
//     public void SetMusicVolume(float volume)
//     {
//         audioSource.volume = Mathf.Clamp01(volume); // Ensure the volume stays between 0 and 1
//     }

//     // Method to stop the music
//     public void StopMusic()
//     {
//         audioSource.Stop();
//     }
// }
