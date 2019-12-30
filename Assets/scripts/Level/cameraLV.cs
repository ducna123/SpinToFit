using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLV : MonoBehaviour {

    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    //public GameObject panel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.active == true)           
        {
            if (player.transform.position.y <= transform.position.y + 1.5f)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y - 1.5f, transform.position.z);
            }

            if (player.transform.position.y >= transform.position.y + 3f)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y - 3f, transform.position.z);
            }
        }
        if (player2.active == true)
        {
            if (player2.transform.position.y <= transform.position.y + 1.5f)
            {
                transform.position = new Vector3(transform.position.x, player2.transform.position.y - 1.5f, transform.position.z);
            }

            if (player2.transform.position.y >= transform.position.y + 3f)
            {
                transform.position = new Vector3(transform.position.x, player2.transform.position.y - 3f, transform.position.z);
            }
        }
        if (player3.active == true)
        {
            if (player3.transform.position.y <= transform.position.y + 1.5f)
            {
                transform.position = new Vector3(transform.position.x, player3.transform.position.y - 1.5f, transform.position.z);
            }

            if (player3.transform.position.y >= transform.position.y + 3f)
            {
                transform.position = new Vector3(transform.position.x, player3.transform.position.y - 3f, transform.position.z);
            }
        }

        if (player4.active == true)
        {
            if (player4.transform.position.y <= transform.position.y + 1.5f)
            {
                transform.position = new Vector3(transform.position.x, player4.transform.position.y - 1.5f, transform.position.z);
            }

            if (player4.transform.position.y >= transform.position.y + 3f)
            {
                transform.position = new Vector3(transform.position.x, player4.transform.position.y - 3f, transform.position.z);
            }
        }

    }
}
