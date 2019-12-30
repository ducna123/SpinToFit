using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLV2 : MonoBehaviour {
    private Rigidbody2D myBody;
    float z;
    float euler;
    public ParticleSystem noF;
    public ParticleSystem coin;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    int star;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        euler = 1.75f;
        star = GameManager.instance._GetBestS();
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
            euler = -euler;
            myBody.velocity = new Vector2(0, 4);
        }
        z += euler;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "vc")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(die);
            }
            Debug.Log("ân");
            Instantiate(noF, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            LV.instance._delayendGL();
        }
        if (other.gameObject.tag == "pass")
        {
            this.gameObject.SetActive(false);
            LV.instance._delayendGW();
        }
    }

}
