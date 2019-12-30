using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vc7 : MonoBehaviour {
    public GameObject C;
    public GameObject L;
    public GameObject R;
    private float speedL;
    private float speedR;
    // Use this for initialization
    void Start () {
        speedL = 0.7f;
        speedR = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
        if (L.transform.position.x >= C.transform.position.x - 2.8f)
        {
            speedL = -Mathf.Abs(speedL);
        }
        if (L.transform.position.x <= C.transform.position.x - 4.2f)
        {
            speedL = Mathf.Abs(speedL);
        }
        L.transform.Translate(Vector3.right * Time.deltaTime * speedL);
        if (R.transform.position.x <= C.transform.position.x + 2.8f)
        {
            speedR = -Mathf.Abs(speedR);
        }
        if (R.transform.position.x >= C.transform.position.x + 4.2f)
        {
            speedR = Mathf.Abs(speedR);
        }
        R.transform.Translate(Vector3.left * Time.deltaTime * speedR);
    }
}
