using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WwiseNetwork : NetworkBehaviour {
    bool serverStarted = false;
    ResultScreen resultScreenManager = null;
    
    [Command]
    void CmdPlaySound(string eventName) {
        Debug.LogError("Hello world");
        // AkSoundEngine.PostEvent("congrats", gameObject);
    }

    [Command]
    void CmdTrackImage(string albumName, int id) {
        if(resultScreenManager != null) {
            switch(albumName) {
                case "L":
                    resultScreenManager.Leonie[id - 1] = true;
                    break;

                case "R":
                    resultScreenManager.Roman[id - 1] = true;
                    break;
            }
        } else {
            Debug.Log("Result screen not found");
        }
    }

    void Update() {
        if (!isClient) {
            if(resultScreenManager == null) {
                resultScreenManager = GameObject.FindGameObjectWithTag("ResultScreen").GetComponent<ResultScreen>();
                Debug.Log("HELLO");
            }
            return;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Debug.LogError("TOUCH OVER NETWORK");
            CmdPlaySound("normal sound");
        }
    }

    public void TrackImage(string albumName, int id) {
        CmdTrackImage(albumName, id);
    }
}