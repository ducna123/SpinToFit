using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject player;

	void FixedUpdate () {
        if(player.transform.position.y <= transform.position.y+1.5f )
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y-1.5f, transform.position.z);
        }

        if (player.transform.position.y >= transform.position.y + 3f)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 3f, transform.position.z);
            
        }
    }
}