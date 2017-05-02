using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupChild : MonoBehaviour {

    public void OnValidate() {
        MeshFilter mf = GetComponent<MeshFilter>();
        if(mf.sharedMesh != null) {
            Mesh meshCopy = Mesh.Instantiate(mf.sharedMesh) as Mesh;
            gameObject.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh = meshCopy;
        } else {
            Debug.Log("Deb");
        }
    }
}
