using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLV : MonoBehaviour {
    private Rigidbody2D myBody;
    float z;
    public static playerLV instance;
    public ParticleSystem no;
    int star;
    public ParticleSystem coin;
    public AudioSource audio;
    public AudioClip die, ting, fall, jump;
    bool isPut;

	// Use this for initialization
	void Start () {
        star = GameManager.instance._GetBestS();
        myBody = GetComponent<Rigidbody2D>();
        z = 0;
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
        transform.Rotate(new Vector3(0, 0, 2));
        //transform.rotation = Quaternion.Euler(0, 0, z);
        //z += 1.4f;
        if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(0, 5);
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
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
            Debug.Log("ân");
            Instantiate(no, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            LV.instance._delayendGL();
        }
        if(other.gameObject.tag == "pass")
        {
            this.gameObject.SetActive(false);
            LV.instance._delayendGW();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "star")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(ting);
            }
            star += 1;
            Instantiate(coin, other.gameObject.transform.position, Quaternion.identity);
            LV.instance._setS(star);
            GameManager.instance._SetBestS(star);
            Destroy(other.gameObject);
        }

    }

}
