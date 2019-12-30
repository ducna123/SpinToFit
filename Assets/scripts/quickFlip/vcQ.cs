using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcQ : MonoBehaviour {
    private GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y > ball.transform.position.y + 10)
        {
            Destroy(this.gameObject);
            SpawnQ.instance.SpawnerQ();
            SpawnQ.instance.SpawnerQ();
        }
    }
}
