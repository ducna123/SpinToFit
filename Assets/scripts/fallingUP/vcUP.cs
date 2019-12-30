using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcUP : MonoBehaviour {
    private GameObject ball;
    bool isPoint;
    // Use this for initialization
    void Start()
    {
        isPoint = true;
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < ball.transform.position.y - 10)
        {
            Destroy(this.gameObject);
            SpawnF.instance.Spawner();
        }
        if (transform.position.y < ball.transform.position.y - 3 && isPoint == true)
        {
            playerF.instance.point++;
            upController.instance._setP(playerF.instance.point);
            isPoint = false;
        }
    }
}
