using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpriteAnimation : MonoBehaviour {
    public bool lastFrames = false;
    public List<Sprite> frames = new List<Sprite>();
    public List<Sprite> framesEnd = new List<Sprite>();
    public int framesPerSecond = 12;

    private Image image;
    private bool stop = false;
    private float startTime = 0.0f;
    private int lastIndex = 0;

    void Start () {
        image = GetComponent<Image>();
        if(lastFrames) {
            framesEnd = frames.Skip(frames.Count - 6).ToList();
        }
    }
	
	void Update () {
		if(gameObject.activeSelf) {
            // Manage image animation
            if(lastFrames && stop) {
                int index = (int)((Time.time - startTime) * framesPerSecond);
                index = index % framesEnd.Count;

                image.sprite = framesEnd[index];
            } else {
                int index = (int)((Time.time - startTime) * framesPerSecond);
                index = index % frames.Count;
                image.sprite = frames[index];

                if (index == frames.Count - 1) {
                    stop = true;
                }
            }
        }
	}
}
