using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManagerAuto : MonoBehaviour {
    public GameObject debugLog;
    public GameObject debugLog2;

    private NetworkManager manager;

    void Awake() {
        manager = GetComponent<NetworkManager>();
    }

    void Update() {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
            if(!NetworkServer.active) {
                manager.StartServer();
            }
        } else if (Application.platform == RuntimePlatform.Android) {
            bool noConnection = (manager.client == null || manager.client.connection == null ||
                                 manager.client.connection.connectionId == -1);

            if (noConnection) {
                manager.StartClient();
                debugLog.GetComponent<Text>().text = "Disconnected";
                debugLog2.GetComponent<Text>().text = manager.networkPort + "";
            } else {
                debugLog.GetComponent<Text>().text = "Connected";
            }
        }
    }
}
