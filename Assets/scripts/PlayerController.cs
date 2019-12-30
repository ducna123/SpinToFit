using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float z;
    private Rigidbody2D myBody;
    public bool isPut;
    public static PlayerController instance;
    public int point = 0;
    public int star = 0;
    public ParticleSystem noT;
    public ParticleSystem coin;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    private bool isDead;


    // Use this for initialization
    void Start () {
        isDead = false;
        z = 0;
        isPut = false;
        myBody = GetComponent<Rigidbody2D> ();
        star = GameManager.instance._GetBestS();
        NormalController.instance._setS(star);
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
        transform.Rotate(new Vector3(0, 0, 2f));
        if (Input.GetMouseButtonDown(0))
        {
            isPut = true;
            if(PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
            myBody.velocity = new Vector3(0,5,0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPut = false;
        }
        if(isPut == false)
        {
            if(audio.isPlaying == false)
            {
                //audio.PlayOneShot(fall);
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
            Vector3 temp = transform.position;
            Instantiate(noT, temp, Quaternion.identity);
            this.gameObject.SetActive(false);
            GameManager.instance._SetBestS(star);
            NormalController.instance.delayEndG();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "star")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(ting);
            }
            star += 1;
            Instantiate(coin, other.gameObject.transform.position, Quaternion.identity);
            NormalController.instance._setS(star);
            Destroy(other.gameObject);
        }
        
    }
}
