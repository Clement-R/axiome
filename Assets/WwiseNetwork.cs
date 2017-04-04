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
    }

    void Update() {
        if (!isClient)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.LogError("SPACE NETWORK");
            CmdPlaySound("normal sound");
        }
    }
}