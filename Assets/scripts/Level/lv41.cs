using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv41 : MonoBehaviour {
    public GameObject p1;
    public GameObject star;
    int d = 0;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        if (player.active == false)
        {
            d++;
            if (d == 200)
            {
                p1.SetActive(true);
                star.SetActive(true);
                d = 0;
            }
        }
        if (player.transform.position.y <= 0.02f && player.active == true)
        {
            p1.SetActive(false);
            star.SetActive(false);
        }
    }
}
