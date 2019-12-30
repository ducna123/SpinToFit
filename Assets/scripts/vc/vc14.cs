using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc14 : MonoBehaviour {
    private Vector3 v1;
    public GameObject vc;
    // Use this for initialization
    void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        float x = vc.transform.position.x;
        float y = vc.transform.position.y;
        if(transform.position == new Vector3(x-2, y, 0))
        {
            v1 = new Vector3(x+2, y, 0);
        }
        if (transform.position == new Vector3(x+2, y, 0))
        {
            v1 = new Vector3(x+2, y-4, 0);
        }
        if (transform.position == new Vector3(x+2,y-4, 0))
        {
            v1 = new Vector3(x-2, y-4, 0);
        }
        if (transform.position == new Vector3(x-2, y-4, 0))
        {
            v1 = new Vector3(x-2, y, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, v1, Time.deltaTime * 1.5f);
    }
}
