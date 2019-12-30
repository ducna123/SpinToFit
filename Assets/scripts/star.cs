using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
    private GameObject player;
    public GameObject Star;
    int d = 0;
    int t;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        t = 10;
	}
	
	// Update is called once per frame
	void Update () {
        d++;
        if(d == 100)
        {
            Spawner();
            d = 0;
        }
	}

    void Spawner()
    {
        Vector3 temp = new Vector3(player.transform.position.x, player.transform.position.y - t, player.transform.position.z);
        Instantiate(Star, temp, Quaternion.identity);
        t += 10;
    }
}
