using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Vuforia;

public class WwiseNetwork : NetworkBehaviour {
    bool serverStarted = false;
    ResultScreen resultScreenManager = null;

    [Command]
    void CmdTrackImage(string albumName, int id) {
        if(resultScreenManager != null) {

            Debug.LogWarning("Scan received : " + albumName + " : " + id);

            switch (albumName) {
                case "L":
                    resultScreenManager.Leonie[id - 1] = true;
                    break;

                case "R":
                    resultScreenManager.Roman[id - 1] = true;
                    break;

                case "M":
                    resultScreenManager.Marcel[id - 1] = true;
                    break;

                case "P":
                    resultScreenManager.Perle[id - 1] = true;
                    break;

                case "A":
                    resultScreenManager.Aglae1[id - 1] = true;
                    break;

                case "B":
                    resultScreenManager.Aglae2[id - 1] = true;
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
    }

    public void TrackImage(List<Vuforia.DefaultTrackableEventHandler.AlbumContent> album) {
        foreach (var image in album) {
            string name = image.albumName;
            int id = image.pictureId;

            Debug.LogWarning("Scan send : " + name + " : " + id);
            CmdTrackImage(name, id);
        }
    }
}