using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc17 : MonoBehaviour {
    private Vector3 v1;
    public GameObject top;
    public GameObject bot;
    public GameObject p1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //.Log(p1.transform.position.y);
        if (p1.transform.position.y >= transform.position.y-0.5f)
        {
            v1 = new Vector3(0, transform.position.y-1f, 0);
            //Debug.Log("xuong");
        }
        if (p1.transform.position.y <= transform.position.y - 1f)
        {
            v1 = new Vector3(0, transform.position.y-0.5f, 0);
        }
        p1.transform.position = Vector3.MoveTowards(p1.transform.position, v1, Time.deltaTime * 1.5f);
    }
}
