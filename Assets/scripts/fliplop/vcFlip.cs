using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcFlip : MonoBehaviour {
    private GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.transform.position.y);
        //Debug.Log(ball.transform.position.y);
        if (this.transform.position.y > ball.transform.position.y + 2)
        {
            
            spawnFlip.instance.SpawnerFlip();
            spawnFlip.instance.SpawnerFlip();
        }
        if(this.transform.position.y > ball.transform.position.y + 2)
        {
            playerFlip.instance.point++;
            flipController.instance._setP(playerFlip.instance.point);
            Destroy(this.gameObject);
        }
    }
}
