using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip chaseSound;
    private bool isPlaying;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (EnemySight.isSpottedAudio){
            if (audioSource.clip == chaseSound) return;
            isPlaying = true;
            audioSource.clip = chaseSound;
            audioSource.Play();
        } else {
            if (audioSource.clip == chaseSound) {
                if (isPlaying) audioSource.volume -= 0.01f;
                if (audioSource.volume <= 0) {
                    audioSource.clip = null;
                    audioSource.Stop();
                    audioSource.volume = 0.2f;
                    isPlaying = false;
                }
            }
        }
    }
}
