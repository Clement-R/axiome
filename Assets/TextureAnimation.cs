using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {
    public List<Texture2D> frames = new List<Texture2D>();
    public int framesPerSecond = 10;

    private float timer = 0.0f;
    private Renderer renderer;
    // private AudioSource audio;
    private uint eventId = 0;

    void Start() {
        renderer = GetComponent<Renderer>();
    }

    void Update() {
        // Manage texture animation
        int index = (int) (Time.time * framesPerSecond);
        index = index % frames.Count;
        renderer.material.mainTexture = frames[index];
        
        // Manage sound
        if(renderer.enabled) {
            if (eventId == 0) {
                eventId = AkSoundEngine.PostEvent("mood_test", gameObject, (uint)AkCallbackType.AK_EndOfEvent, SoundEndCallback, null);
            }
        } else {
            if (eventId != 0) {
                AkSoundEngine.StopPlayingID(eventId);
                eventId = 0;
            }
        }
    }

    void SoundEndCallback (object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
            eventId = 0;
        }
    }
}
