using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour {
    public List<Texture2D> frames = new List<Texture2D>();
    public int framesPerSecond = 10;

    private float timer = 0.0f;
    private Renderer renderer;
    private bool stop = false;

    void Start() {
        renderer = GetComponent<Renderer>();
    }

    void Update() {
        if(!stop) {
            // Manage texture animation
            int index = (int)(Time.time * framesPerSecond);
            index = index % frames.Count;
            renderer.material.mainTexture = frames[index];

            if (index == frames.Count - 1) {
                stop = true;
            }
        }
    }
}
