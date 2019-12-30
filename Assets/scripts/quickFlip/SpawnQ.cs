using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQ : MonoBehaviour {
    public List<GameObject> vc;
    public static SpawnQ instance;
    float start;
	// Use this for initialization
	void Start () {
        start = -17;
        _MakeInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SpawnerQ()
    {
        float t = Random.Range(0,4);
        Vector3 temp = vc[(int)t].transform.position;
        float y = Random.Range(6, 7);
        temp.y = start - y;
        start -= y;
        Instantiate(vc[(int)t], temp, Quaternion.identity);
    }
}
