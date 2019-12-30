using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour {
    float z;
    float euler;
    public int point;
    public ParticleSystem no;
    public static playerOne instance;
    public AudioSource audio;
    public AudioClip jump, die;
	// Use this for initialization
	void Start () {
        z = 0;
        euler = 2.5f;
        point = 0;
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
        if (Input.GetMouseButtonDown(0))
        {
            euler = -euler;
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
        }
        z += euler;
        transform.rotation = Quaternion.Euler(0, 0, z);
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "vc")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(die);
            }
            this.gameObject.SetActive(false);
            Vector3 temp = transform.position;
            Instantiate(no, temp, Quaternion.identity);
            onecontroller.instance.delayendG();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "point")
        {
            point++;
            onecontroller.instance._setP(point);
            Destroy(other.gameObject);
        }
    }

}
