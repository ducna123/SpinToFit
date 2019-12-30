using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnO : MonoBehaviour {
    public static spawnO instance;
    public List<GameObject> vc;
    float start;
    
	// Use this for initialization
	void Start () {
        start = -14.2f;
        _MakeInstance();
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

    public void SpawnerO()
    {
        float t = Random.Range(0, 3);
        float i = Random.Range(0, 3);
        Vector3 temp1 = vc[(int)t].transform.position;
        Vector3 temp2 = vc[(int)i].transform.position;
        temp1.y = start - 3;
        temp2.y = start - 5.6f;
        start -= 5.6f;
        Instantiate(vc[(int)t], temp1, Quaternion.identity);
        Instantiate(vc[(int)i], temp2, Quaternion.identity);
    }
}
