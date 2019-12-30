using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public List<GameObject> vc;
    int d = 0;
    float start;
    float t;
    public static Spawn instance;
    private bool isSpawn;
    float last;
    // Use this for initialization
    void Start () {
        d = 0;
        start = -28f;
        _MakeInstance();
        isSpawn = false;
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

     public void Spawner()
     {
        t = Random.Range(0, 18);
        Vector3 temp = vc[(int)t].transform.position;
        //temp.x = 0;
        temp.y = start - 10f;
        start -= 10f;
        Instantiate(vc[(int)t], temp, Quaternion.identity);
     }
}
