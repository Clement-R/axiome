using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerAuto : MonoBehaviour {
    private NetworkManager manager;
    private NetworkClient client = null;

    void Awake() {
        manager = GetComponent<NetworkManager>();
    }

    void Update() {
        if (Application.platform == RuntimePlatform.WindowsPlayer) {
            if(!NetworkServer.active) {
                manager.StartServer();
            }
        }

        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor) {
            if(client == null) {
                client = manager.StartClient();
            }
        }
    }
}
