using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreen : MonoBehaviour {
    private GameObject networkManager;

    public GameObject Leonie_50;
    public GameObject Leonie_100;
    public GameObject Roman_50;
    public GameObject Roman_100;

    int index = 0;

    public List<bool> Leonie = new List<bool>();
    public List<bool> Roman = new List<bool>();

    void Start () {
        for (int i = 0; i < 17; i++) {
            Leonie.Add(false);
        }

        for (int i = 0; i < 11; i++) {
            Roman.Add(false);
        }
    }
	
	void Update () {
        // LEONIE ALBUM
        if (Leonie.FindAll(e => e == true).Count /*> Leonie.Count / 2*/ == 1) {
            // Show first step
            Leonie_50.SetActive(true);
        }

        if (Leonie.FindAll(e => e == true).Count /*> Leonie.Count / 2*/ == 2) {
            // Show first step
            Leonie_100.SetActive(true);
        }

        if (!Leonie.Contains(false)) {
            // Show second step (full)
            Leonie_100.SetActive(true);
        }

        // ROMAN ALBUM
        if (Roman.FindAll(e => e == true).Count /*> Roman.Count / 2*/ == 1) {
            // Show first step
            Roman_50.SetActive(true);
        }

        if (Roman.FindAll(e => e == true).Count /*> Roman.Count / 2*/ == 2) {
            // Show first step
            Roman_100.SetActive(true);
        }

        if (!Roman.Contains(false)) {
            // Show second step (full)
            Roman_100.SetActive(true);
        }
        
        if(Input.GetKeyDown(KeyCode.R)) {

            for (int i = 0; i < Leonie.Count; i++) {
                Leonie[i] = false;
            }

            for (int i = 0; i < Roman.Count; i++) {
                Roman[i] = false;
            }

            Leonie_50.SetActive(false);
            Leonie_100.SetActive(false);
            Roman_50.SetActive(false);
            Roman_100.SetActive(false);

            index = 0;
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
