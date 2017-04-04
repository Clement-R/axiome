using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {
    public List<Texture2D> frames = new List<Texture2D>();
    public int framesPerSecond = 10;

    private float timer = 0.0f;
    private Renderer renderer;
    private AudioSource audio;

    void Start() {
        renderer = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        int index = (int) (Time.time * framesPerSecond);
        index = index % frames.Count;
        renderer.material.mainTexture = frames[index];

        if (renderer.enabled) {
            if(!audio.isPlaying) {
                audio.Play();
            }
        } else {
            if (audio.isPlaying) {
                audio.Stop();
            }
        }
    }
}
