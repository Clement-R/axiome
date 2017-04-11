using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlaySound : NetworkBehaviour {
	void Start () {
        AkSoundEngine.PostEvent("mood_test", gameObject);
    }
}
