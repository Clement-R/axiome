using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WwiseNetwork : NetworkBehaviour {
    bool serverStarted = false;
    
    [Command]
    void CmdPlaySound(string eventName) {
        Debug.LogError("Hello world");
        AkSoundEngine.PostEvent("congrats", gameObject);
    }

    void Update() {
        if (!isClient)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Debug.LogError("TOUCH OVER NETWORK");
            CmdPlaySound("normal sound");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.LogError("SPACE NETWORK");
            CmdPlaySound("normal sound");
        }
    }
}