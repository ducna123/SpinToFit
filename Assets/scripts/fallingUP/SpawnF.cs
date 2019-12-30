using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnF : MonoBehaviour {
    public List<GameObject> vc1;
    int d = 0;
    float start;
    float t;
    public static SpawnF instance;
    private bool isSpawn;
    float last;
    // Use this for initialization
    void Start()
    {
        d = 0;
        start = 45f;
        _MakeInstance();
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        t = Random.Range(0, 20);
        Vector3 temp = vc1[(int)t].transform.position;
        //temp.x = 0;
        temp.y = start + 10f;
        start += 10f;
        Debug.Log((int)t);
        Instantiate(vc1[(int)t], temp, Quaternion.identity);
    }
}
