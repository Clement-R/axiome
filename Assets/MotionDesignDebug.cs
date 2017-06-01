using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDesignDebug : MonoBehaviour {
	void Start () {
        Object[] texts = Resources.LoadAll("MotionDesign", typeof(GameObject));

        foreach (var text in texts) {
            GameObject obj = Instantiate(text, transform) as GameObject;
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);
        }	
	}
}
