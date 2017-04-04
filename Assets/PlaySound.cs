using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlaySound : NetworkBehaviour {
    public GameObject audioSourcePrefab;

    private GameObject audioSource;

	void Start () {
        audioSource = Instantiate(audioSourcePrefab);
    }

    /*
    void override OnStartServer() {
        if(isServer && )
    }
    */
}
