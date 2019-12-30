using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLV4 : MonoBehaviour {
    private Rigidbody2D myBody;
    float z;
    float euler1;
    float euler2;
    public ParticleSystem noF;
    public ParticleSystem coin;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    int star;
    float eu;
    int check;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        euler1 = 0.5f;
        euler2 = 4f;
        eu = 0.5f;
        star = GameManager.instance._GetBestS();
        check = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
            if (eu == euler1)
            {
                Debug.Log(eu);
                check = 2;
            }
            if (eu == euler2)
            {
                check = 1;
            }
            myBody.velocity = new Vector2(0, 4);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(check == 2)
            {
                eu = euler2;
            }
            if (check == 1)
            {
                eu = euler1;
            }
        }
        Debug.Log(eu);
        z += eu;
        transform.rotation = Quaternion.Euler(0, 0, z);
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
