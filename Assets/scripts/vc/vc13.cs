using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc13 : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    private float speed1;
    private float speed2;
    // Use this for initialization
    void Start () {
        speed1 = 0.7f;
        speed2 = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
		if(p1.transform.position.x <= 0)
        {
            speed1 = Mathf.Abs(speed1);
        }
        if(p1.transform.position.x >= 2.7f)
        {
            speed1 = -Mathf.Abs(speed1);
        }
        p1.transform.Translate(Vector3.right * Time.deltaTime * speed1);
        if (p2.transform.position.x <= -2.7f)
        {
            speed2 = Mathf.Abs(speed2);
        }
        if (p2.transform.position.x >= 0)
        {
            speed2 = -Mathf.Abs(speed2);
        }
        p2.transform.Translate(Vector3.right * Time.deltaTime * speed2);
    }
}
