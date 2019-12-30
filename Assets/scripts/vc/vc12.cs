using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc12 : MonoBehaviour {
    float z;
    // Use this for initialization
    void Start () {
        z = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, z);
        z += 0.5f;
    }
}
