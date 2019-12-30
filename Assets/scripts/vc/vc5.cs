using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc5 : MonoBehaviour {
    private float speed;
    public GameObject L;
    public GameObject R;
	// Use this for initialization
	void Start () {
        speed = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x >= R.transform.position.x-1.7f)
        {
            speed = -speed;
        }
        if (transform.position.x <= L.transform.position.x+1.7f)
        {
            speed = Mathf.Abs(speed);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

}
