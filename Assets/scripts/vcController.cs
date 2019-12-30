using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcController : MonoBehaviour {
    private GameObject ball;
    bool isP;
    public static vcController instance;
	// Use this for initialization
	void Start () {
        isP = true;
        _MakeInstance();
        ball = GameObject.FindGameObjectWithTag("Player");
	}

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y > ball.transform.position.y + 10)
        {
            Destroy(this.gameObject);
            Spawn.instance.Spawner();
        }
        if (transform.position.y >= ball.transform.position.y + 4 && isP == true)
        {
            isP = false;
            PlayerController.instance.point++;
            NormalController.instance._setP(PlayerController.instance.point);
        }
    }
}
