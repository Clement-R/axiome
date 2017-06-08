using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {
    private GameObject networkManager;

    public int experienceDuration = 720;
    public bool debug = false;

    public GameObject Leonie_50;
    public GameObject Leonie_100;

    public GameObject Roman_50;
    public GameObject Roman_100;

    public GameObject Perle_100;

    public GameObject Aglae1_50;
    public GameObject Aglae1_100;

    public GameObject Aglae2_50;
    public GameObject Aglae2_100;

    public GameObject Marcel_50;
    public GameObject Marcel_100;

    public GameObject endPanel;
    public GameObject endImage;

    public int leonieCount = 14;
    public int romanCount = 9;
    public int perleCount = 1;
    public int aglae1Count = 4;
    public int aglae2Count = 6;
    public int marcelCount = 10;

    int index = 0;

    public List<bool> Leonie = new List<bool>();
    public List<bool> Roman = new List<bool>();
    public List<bool> Perle = new List<bool>();
    public List<bool> Aglae1 = new List<bool>();
    public List<bool> Aglae2 = new List<bool>();
    public List<bool> Marcel = new List<bool>();

    public float startTime = 0.0f;

    static private uint eventId = 0;
    static private bool canPlaySound = true;
    static private bool endSound = false;

    IEnumerator unlockSoundSemaphor() {
        canPlaySound = false;
        yield return new WaitForSeconds(1.5f);
        canPlaySound = true;
    }

    void PlayProgressionSound() {
        if (canPlaySound) {
            eventId = AkSoundEngine.PostEvent("Tableau_progression", gameObject, (uint)AkCallbackType.AK_EndOfEvent, SoundEndCallback, null);
            StartCoroutine("unlockSoundSemaphor");
        }
    }

    IEnumerator PlayCompleteSound() {
        if(!endSound) {
            endSound = true;
            yield return new WaitForSeconds(0.2f);
            AkSoundEngine.PostEvent("tableau_complete", gameObject, (uint)AkCallbackType.AK_EndOfEvent, SoundCompleteEndCallback, null);
        }
    }

    void SoundCompleteEndCallback(object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
            endSound = false;
        }
    }

    void SoundEndCallback(object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
            eventId = 0;
        }
    }

    void Start() {
        for (int i = 0; i < leonieCount; i++) {
            Leonie.Add(false);
        }

        for (int i = 0; i < romanCount; i++) {
            Roman.Add(false);
        }

        for (int i = 0; i < perleCount; i++) {
            Perle.Add(false);
        }

        for (int i = 0; i < aglae1Count; i++) {
            Aglae1.Add(false);
        }

        for (int i = 0; i < aglae2Count; i++) {
            Aglae2.Add(false);
        }

        for (int i = 0; i < marcelCount; i++) {
            Marcel.Add(false);
        }

        startTime = Time.time;
    }

    IEnumerator ShowImage(Image image, float delay = 0f) {
        if (delay != 0f) {
            yield return new WaitForSeconds(delay);
        }

        float elapsedTime = 0;
        Color used = image.GetComponent<Image>().color;

        while (elapsedTime < 1.5f) {
            image.color = new Color(used.r, used.g, used.b, Mathf.Lerp(0, 1, (elapsedTime / 1.5f)));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    void Update() {
        if(debug) {
            for (int i = 0; i < Leonie.Count; i++) {
                Leonie[i] = true;
            }

            for (int i = 0; i < Roman.Count; i++) {
                Roman[i] = true;
            }

            for (int i = 0; i < perleCount; i++) {
                Perle[i] = true;
            }

            for (int i = 0; i < aglae1Count; i++) {
                Aglae1[i] = true;
            }

            for (int i = 0; i < aglae2Count; i++) {
                Aglae2[i] = true;
            }

            for (int i = 0; i < marcelCount; i++) {
                Marcel[i] = true;
            }
        }

        // LEONIE ALBUM
        if (Leonie.FindAll(e => e == true).Count == 1) {
            // Show first step
            if (Leonie_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Leonie_50.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        if (!Leonie.Contains(false)) {
            // Show second step (full)
            if (Leonie_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Leonie_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // ROMAN ALBUM
        if (Roman.FindAll(e => e == true).Count == 1) {
            // Show first step
            if (Roman_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Roman_50.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        if (!Roman.Contains(false)) {
            // Show second step (full)
            if (Roman_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Roman_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // Aglae1
        if (Aglae1.FindAll(e => e == true).Count == 1) {
            // Show first step
            if (Aglae1_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Aglae1_50.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        if (!Aglae1.Contains(false)) {
            // Show second step (full)
            if (Aglae1_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Aglae1_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // Aglae2
        if (Aglae2.FindAll(e => e == true).Count == 1) {
            // Show first step
            if (Aglae2_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Aglae2_50.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        if (!Aglae2.Contains(false)) {
            // Show second step (full)
            if (Aglae2_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Aglae2_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // Marcel
        if (Marcel.FindAll(e => e == true).Count == 1) {
            // Show first step
            if (Marcel_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Marcel_50.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        if (!Marcel.Contains(false)) {
            // Show second step (full)
            if (Marcel_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Marcel_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // Perle
        if (!Perle.Contains(false)) {
            // Show second step (full)
            if (Perle_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Perle_100.GetComponent<Image>()));
                PlayProgressionSound();
            }
        }

        // MANAGE END OF EXPERIENCE
        // All discovered
        if (!Roman.Contains(false) && !Leonie.Contains(false) && !Perle.Contains(false) && !Aglae1.Contains(false) && !Aglae2.Contains(false) && !Marcel.Contains(false)) {
            if (endImage.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(endImage.GetComponent<Image>(), 0.8f));
                StartCoroutine("PlayCompleteSound");
            }
        }

        // After 10mins
        if (Time.time - startTime > experienceDuration) {
            if (endPanel.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(endPanel.GetComponent<Image>()));
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {

            // RESET LISTS
            for (int i = 0; i < Leonie.Count; i++) {
                Leonie[i] = false;
            }

            for (int i = 0; i < Roman.Count; i++) {
                Roman[i] = false;
            }

            for (int i = 0; i < perleCount; i++) {
                Perle[i] = false;
            }

            for (int i = 0; i < aglae1Count; i++) {
                Aglae1[i] = false;
            }

            for (int i = 0; i < aglae2Count; i++) {
                Aglae2[i] = false;
            }

            for (int i = 0; i < marcelCount; i++) {
                Marcel[i] = false;
            }

            // RESET IMAGES TRANSPARENCY
            Color used = Leonie_50.GetComponent<Image>().color;
            Leonie_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Leonie_100.GetComponent<Image>().color;
            Leonie_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Roman_50.GetComponent<Image>().color;
            Roman_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Roman_100.GetComponent<Image>().color;
            Roman_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);


            used = Perle_100.GetComponent<Image>().color;
            Perle_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Aglae1_50.GetComponent<Image>().color;
            Aglae1_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Aglae1_100.GetComponent<Image>().color;
            Aglae1_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Aglae2_50.GetComponent<Image>().color;
            Aglae2_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Aglae2_100.GetComponent<Image>().color;
            Aglae2_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Marcel_50.GetComponent<Image>().color;
            Marcel_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Marcel_100.GetComponent<Image>().color;
            Marcel_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = endPanel.GetComponent<Image>().color;
            endPanel.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = endImage.GetComponent<Image>().color;
            endImage.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            // RESET DEBUG
            index = 0;

            // RESET TIMER
            startTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            Leonie[index] = true;
            index++;
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            Roman[index] = true;
            index++;
        }
    }
}
