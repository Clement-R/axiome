using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {
    public List<Texture2D> frames = new List<Texture2D>();
    public int framesPerSecond = 10;

    private float timer = 0.0f;

    void Update() {
        int index = (int) (Time.time * framesPerSecond);
        index = index % frames.Count;
        GetComponent<Renderer>().material.mainTexture = frames[index];

        // timer = (timer + Time.deltaTime * framesPerSecond) % frames.Count;
        // Debug.Log(timer);
        // GetComponent<SpriteRenderer>().sprite = frames[(int) timer];
    }
}
