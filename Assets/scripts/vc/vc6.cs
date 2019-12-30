using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc6 : MonoBehaviour {
    private float speed;
    public GameObject L;
    public GameObject R;
    // Use this for initialization
    void Start () {
        speed = 0.7f;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= R.transform.position.x - 2.1f)
        {
            speed = -Mathf.Abs(speed);
        }
        if (transform.position.x <= L.transform.position.x + 2.1f)
        {
            speed = Mathf.Abs(speed);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
