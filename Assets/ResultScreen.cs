using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {
    private GameObject networkManager;

    public GameObject Leonie_50;
    public GameObject Leonie_100;
    public GameObject Roman_50;
    public GameObject Roman_100;

    int index = 0;

    public List<bool> Leonie = new List<bool>();
    public List<bool> Roman = new List<bool>();

    public float startTime = 0.0f;

    void Start () {
        for (int i = 0; i < 17; i++) {
            Leonie.Add(false);
        }

        for (int i = 0; i < 9; i++) {
            Roman.Add(false);
        }

        startTime = Time.time;
    }

    IEnumerator ShowImage(Image image) {
        float elapsedTime = 0;
        Color used = image.GetComponent<Image>().color;

        while (elapsedTime < 1.5f) {
            image.color = new Color(used.r, used.g, used.b, Mathf.Lerp(0, 1, (elapsedTime / 1.5f)));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    void Update () {
        // LEONIE ALBUM
        if (Leonie.FindAll(e => e == true).Count > (Leonie.Count / 2)) {
            // Show first step
            // Color used = Leonie_50.GetComponent<Image>().color;
            // Leonie_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 1);
            if(Leonie_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Leonie_50.GetComponent<Image>()));
            }
        }

        if (!Leonie.Contains(false)) {
            // Show second step (full)
            if (Leonie_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Leonie_100.GetComponent<Image>()));
            }
        }

        // ROMAN ALBUM
        if (Roman.FindAll(e => e == true).Count > Roman.Count / 2) {
            // Show first step
            if (Roman_50.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Roman_50.GetComponent<Image>()));
            }
        }

        if (!Roman.Contains(false)) {
            // Show second step (full)
            if (Roman_100.GetComponent<Image>().color.a == 0) {
                StartCoroutine(ShowImage(Roman_100.GetComponent<Image>()));
            }
        }

        // After 10mins
        if (Time.time - startTime > 600) {
            Debug.Log("End of the experience");
        }
        
        if(Input.GetKeyDown(KeyCode.R)) {

            for (int i = 0; i < Leonie.Count; i++) {
                Leonie[i] = false;
            }

            for (int i = 0; i < Roman.Count; i++) {
                Roman[i] = false;
            }

            Color used = Leonie_50.GetComponent<Image>().color;
            Leonie_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Leonie_100.GetComponent<Image>().color;
            Leonie_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Roman_50.GetComponent<Image>().color;
            Roman_50.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            used = Roman_100.GetComponent<Image>().color;
            Roman_100.GetComponent<Image>().color = new Color(used.r, used.g, used.b, 0);

            index = 0;

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
