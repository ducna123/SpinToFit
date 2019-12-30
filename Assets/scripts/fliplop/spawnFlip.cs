using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFlip : MonoBehaviour {
    public GameObject vc;
    public static spawnFlip instance;
    float start;
    float last;
	// Use this for initialization
	void Start () {
        _MakeInstance();
        start = -8.4f;
        last = 2f;
        SpawnerFlip();
        SpawnerFlip();
        SpawnerFlip();
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
		
	}
    
    public void SpawnerFlip()
    {
        Vector3 temp = vc.transform.position;
        float t = Random.Range(1, 10);
        if(t > 5)
        {
            temp.x = 2f;
        }
        else
        {
            temp.x = -2f;
        }
        if(temp.x == last)
        {
            temp.y = start - 5.8f;
            start -= 5.8f;
        }
        else
        {
            temp.y = start - 3.5f;
            start -= 3.5f;
        }
        last = temp.x;
        if(temp.x == 2f)
        {
            Instantiate(vc, temp, Quaternion.Euler(0,180,0));
        }
        else
        {
            Instantiate(vc, temp, Quaternion.identity);
        }
        
    }

}
