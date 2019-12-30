using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnT : MonoBehaviour {
    public List <GameObject> vc1;
    public static spawnT instance;
    float start;
	// Use this for initialization
	void Start () {
        _MakeInstance();
        start = -8.6f;
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

    public void SpawnerT()
    {
        float t = Random.Range(0, 5);
        Vector3 temp = vc1[(int)t].transform.position;
        temp.y = start - 3.3f;
        Instantiate(vc1[(int)t], temp, Quaternion.identity);
        Debug.Log(t);
    }

}
