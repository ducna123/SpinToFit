using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anim : MonoBehaviour {
    public Image a;
    public GameObject b;
    float z;
	// Use this for initialization
	void Start () {
        z = 1;
	}
	
	// Update is called once per frame
	void Update () {
        a.color = new Color(0, 0, 0, z);
        if(z >= 0)
        {
            z -= 0.04f;
        }
        if(z <= 0)
        {
            b.SetActive(false); 
        }
	}
}
