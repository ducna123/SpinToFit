using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour {
    float z;
	// Use this for initialization
	void Start () {
        z = transform.localRotation.z * 180;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, z);
        z += 5;
	}
}
