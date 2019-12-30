using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFlip : MonoBehaviour {

    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= transform.position.y + 1.5f)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 1.5f, transform.position.z);
        }

        if (player.transform.position.y >= transform.position.y + 2f)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 2f, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y - 2, transform.position.z), Time.deltaTime * 15);
        }
    }
}
