using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv13 : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(player.active == false)
        {
            p1.SetActive(true);
            bt1.SetActive(true);
            p2.SetActive(true);
            bt2.SetActive(true);
            p3.SetActive(true);
            bt3.SetActive(true);
        }
	    if(player.transform.position.y <= -1.83f && player.active == true)
        {
            p1.SetActive(false);
            bt1.SetActive(false);
        }
        if (player.transform.position.y <= -3.99f && player.active == true)
        {
            p2.SetActive(false);
            bt2.SetActive(false);
        }
        if (player.transform.position.y <= -5.69f && player.active == true)
        {
            p3.SetActive(false);
            bt3.SetActive(false);
        }
    }
}
