using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerAuto : MonoBehaviour {
    public NetworkManager manager;

    void Awake() {
        manager = GetComponent<NetworkManager>();
    }

    void Update() {
        if (Application.platform == RuntimePlatform.WindowsPlayer) {
            if(!NetworkServer.active) {
                manager.StartServer();
            }
        }
        else if (Application.platform == RuntimePlatform.Android) {
            if(!manager.IsClientConnected()) {
                manager.StartClient();
            }
        }
    }
}
