using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAndroid : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android) {
            Debug.Log("Correct");
        }
    }
}
