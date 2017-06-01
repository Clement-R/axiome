using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDesign : MonoBehaviour {
    public int id;

	void Start () {
        Object text = Resources.Load("MotionDesign/text (" + id +")", typeof(GameObject));
        GameObject obj = Instantiate(text, transform) as GameObject;
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);
    }
}
