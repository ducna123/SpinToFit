using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerF : MonoBehaviour {
    private Rigidbody2D myBody;
    float z;
    public int point = 0;
    public static playerF instance;
    public ParticleSystem noU;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    private bool isDead;
    public bool isPut;

    // Use this for initialization
    void Start () {
        point = 0;
        myBody = GetComponent<Rigidbody2D>();
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
        transform.rotation = Quaternion.Euler(0, 0, z);
        z += 1.4f;
        if (Input.GetMouseButtonDown(0))
        {
            isPut = true;
            myBody.velocity = new Vector2(0, -5);
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPut = false;
        }
        if (isPut == false)
        {
            if (audio.isPlaying == false)
            {
                //audio.PlayOneShot(fall);
            }

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
            Instantiate(noU, temp, Quaternion.identity);
            this.gameObject.SetActive(false);
            upController.instance.delayendG();
        }
    }

}
