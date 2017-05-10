using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreen : MonoBehaviour {
    private GameObject networkManager;

    public GameObject Leonie_50;
    public GameObject Leonie_100;
    public GameObject Roman_50;
    public GameObject Roman_100;

    List<bool> Leonie = new List<bool>(17);
    List<bool> Roman = new List<bool>(11);

    void Start () {
        foreach (var b in Leonie) {
            b = false;
        }
	}
	
	void Update () {
	}
}
