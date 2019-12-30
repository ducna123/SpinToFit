using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTemp : MonoBehaviour {
    float z;
    public bool isPut;
    public int point;
    public static playerTemp instance;
    public ParticleSystem no;
    public AudioSource audio;
    public AudioClip die,roll;

	// Use this for initialization
	void Start () {
        z = 0;
        point = 0;
        isPut = false;
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
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(roll);
            }
            isPut = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            audio.Stop();
            isPut = false;
        }
        if(isPut == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, z);
            z += 3;
        }
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "vc")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(die);
            }
            Vector3 temp = transform.position;
            Instantiate(no, temp, Quaternion.identity);
            this.gameObject.SetActive(false);
            tempController.instance.delayendG();
        }
    }
}
