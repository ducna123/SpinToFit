using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcOne : MonoBehaviour {
    bool isP;
    private GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * 2f);
        if(ball.transform.position.y + 10 < this.transform.position.y)
        {
            Destroy(this.gameObject);
            spawnO.instance.SpawnerO();
        }
        if (ball.transform.position.y + 0.2f < this.transform.position.y && isP == false)
        {
            isP = true;
            playerOne.instance.point++;
            onecontroller.instance._setP(playerOne.instance.point);
        }
    }
}
