using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WwiseNetwork : NetworkBehaviour {
    bool serverStarted = false;
    ResultScreen resultScreenManager = null;

    [Command]
    void CmdTrackImage(string albumName, int id) {
        if(resultScreenManager != null) {

            Debug.LogWarning("Scan received : " + albumName + " : " + id);

            switch(albumName) {
                case "L":
                    resultScreenManager.Leonie[id - 1] = true;
                    break;

                case "R":
                    resultScreenManager.Roman[id - 1] = true;
                    break;
            }
        }
    }

    void Update() {
        if (!isClient) {
            if(resultScreenManager == null) {
                resultScreenManager = GameObject.FindGameObjectWithTag("ResultScreen").GetComponent<ResultScreen>();
            }
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            CmdTrackImage("L", Random.Range(1, 10));
        }
    }

    public void TrackImage(string albumName, int id) {
        Debug.LogWarning("Scan send : " + albumName + " : " + id);
        CmdTrackImage(albumName, id);
    }
}