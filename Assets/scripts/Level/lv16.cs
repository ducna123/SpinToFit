using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv16 : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    private GameObject player;
    int d = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update () {
		if(player.active == false)
        {
            d++;
            if(d == 200)
            {
                p1.SetActive(true);
                p2.SetActive(true);
                p3.SetActive(true);
                p4.SetActive(true);
                d = 0;
            }
        }
        if (player.transform.position.y <= -1.27f && player.active == true)
        {
            p1.SetActive(false);
        }
        if (player.transform.position.y <= -5.69f && player.active == true)
        {
            p2.SetActive(false);
        }
        if (player.transform.position.y <= -11.1f && player.active == true)
        {
            p3.SetActive(false);
        }
        if (player.transform.position.y <= -22.24f && player.active == true)
        {
            p4.SetActive(false);
        }

    }
}
