using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlip : MonoBehaviour {
    public int point;
    private Rigidbody2D myBody;
    float z;
    float euler;
    public ParticleSystem noF;
    public static playerFlip instance;
    public AudioSource audio;
    public AudioClip die, ting, jump, fall;
    private bool isDead;
    public bool isPut;

    // Use this for initialization
    void Start()
    {
        point = 0;
        euler = 1.75f;
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
    void Update()
    {
        //Debug.Log(transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (Input.GetMouseButtonDown(0))
        {
            isPut = true;
            euler = -euler;
            myBody.velocity = new Vector2(0, 4);
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audio.PlayOneShot(jump);
            }
        }
        z += euler;
        if (Input.GetMouseButtonUp(0))
        {
            isPut = false;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "vc")
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
            Instantiate(noF, temp, Quaternion.identity);
            this.gameObject.SetActive(false);
            flipController.instance.delayendG();
        }
        
    }
   
}
