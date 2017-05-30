using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour {
    public List<Sprite> frames = new List<Sprite>();
    public int framesPerSecond = 12;

    private Image image;
    private float startTime = 0.0f;

    void Start () {
        image = GetComponent<Image>();
	}
	
	void Update () {
		if(gameObject.activeSelf) {
            // Manage image animation
            int index = (int)((Time.time - startTime) * framesPerSecond);
            index = index % frames.Count;
            image.sprite = frames[index];
        }
	}
}
