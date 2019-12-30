using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv12 : MonoBehaviour {
    public GameObject up;
    public GameObject open;
    public GameObject top;
    private GameObject player;
    bool isUp;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(player.active == false)
        {            
            if(open.active == false)
            {
                Debug.Log("xoa");
                open.SetActive(true);
                top.SetActive(true);
                up.SetActive(false);
            }         
        }
        if(player.transform.position.y <= -8f && player.active == true)
        {
            open.SetActive(false);
            top.SetActive(false);
            up.SetActive(true);
        }
	}

    

}
