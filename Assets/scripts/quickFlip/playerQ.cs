using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerQ : MonoBehaviour {
    float z;
    float euler;
    public int point;
    int d;
    private bool isDead;
    public ParticleSystem no;
    public static playerQ instance;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    public bool isPut;

    // Use this for initialization
    void Start () {
        z = 0;
        isDead = false;
        d = 0;
        point = 0;
        euler = 3;
        _MakeInstance();
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
        d++;
        if(d == 100 && isDead == false)
        {
            point++;
            d = 0;
        }
        quickControllrt.instance._setP(point);
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "vc")
        {
            if (audio.isPlaying == true)
            {
                audio.Stop();
            }
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(die);
            }
            Vector3 temp = transform.position;
            Instantiate(no, temp, Quaternion.identity);
            this.gameObject.SetActive(false);
            quickControllrt.instance.delayendG();
            isDead = true;
        }
    }
}
