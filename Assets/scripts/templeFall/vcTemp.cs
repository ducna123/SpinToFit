using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcTemp : MonoBehaviour {
    public GameObject L;
    public GameObject R;
    private GameObject ball;
    bool isPoint;
    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
        isPoint = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.y <= this.transform.position.y + 5.4f)
        {
            L.transform.Translate(Vector3.right * Time.deltaTime * 0.6f);
            R.transform.Translate(Vector3.left * Time.deltaTime * 0.6f);
        }
	    if(playerTemp.instance.isPut == false)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * 4f);
        }
        if(this.transform.position.y > ball.transform.position.y + 10)
        {
            Destroy(this.gameObject);
            spawnT.instance.SpawnerT();
        }
        if (this.transform.position.y > ball.transform.position.y + 2 && isPoint == true)
        {
            playerTemp.instance.point++;
            tempController.instance._setP(playerTemp.instance.point);
            isPoint = false;
        }
    }
}
