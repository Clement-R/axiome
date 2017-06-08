using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDesign : MonoBehaviour {
    public int id;
    public GameObject textPrefab;
    
    private void OnEnable() {
        Object text = Resources.Load("MotionDesign/text (" + id + ")", typeof(GameObject));
        textPrefab = Instantiate(text, transform) as GameObject;
        textPrefab.transform.position = new Vector3(textPrefab.transform.position.x, textPrefab.transform.position.y, transform.position.z);
    }

    private void OnDisable() {
        Destroy(textPrefab);
    }
}
