using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {
    [Header("Sound")]
    public string WwiseEventName = "mood_test";

    [Space]
    [Header("Animation")]
    public List<Texture2D> frames = new List<Texture2D>();
    public int framesPerSecond = 10;

    private float timer = 0.0f;
    private Renderer renderer;
    // private AudioSource audio;
    private uint eventId = 0;
    private float startTime = 0.0f;

    void Start() {
        renderer = GetComponent<Renderer>();
    }

    void Update() {
        // Manage animation
        if (renderer.enabled) {
            // Manage texture animation
            int index = (int)((Time.time - startTime) * framesPerSecond);
            index = index % frames.Count;
            renderer.material.mainTexture = frames[index];
        }

        if (!renderer.enabled) {
            startTime = Time.time;
        }

        // Manage sound
        if (renderer.enabled) {
            if (eventId == 0 && WwiseEventName != "") {
                eventId = AkSoundEngine.PostEvent(WwiseEventName, gameObject, (uint)AkCallbackType.AK_EndOfEvent, SoundEndCallback, null);
            }
        }
        else {
            if (eventId != 0) {
                AkSoundEngine.StopPlayingID(eventId);
                eventId = 0;
            }
        }
    }

    void SoundEndCallback(object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
            eventId = 0;
        }
    }
}
