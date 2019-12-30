
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonMenu : MonoBehaviour {
    // Use this for initialization
    public AudioSource audio;
    public AudioClip click;
    public Sprite offSound;
    public Sprite onSound;
    public bool sound = true;
    public Button s;
    public static buttonMenu instance;
    static bool isFirst = true;

    void Start () {
        _MakeInstance();
        if(isFirst == true)
        {
            s.image.overrideSprite = onSound;
        }
        else
        {
            if (PlayerPrefs.GetInt("sound") == 0)
            {
               
                s.image.overrideSprite = offSound;
                
            }
            else if (PlayerPrefs.GetInt("sound") == 1)
            {
                
                s.image.overrideSprite = onSound;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _sound()
    {
        if(PlayerPrefs.GetInt("sound") == 1)
        {
            isFirst = false;
            Debug.Log("off");
            s.image.overrideSprite = offSound;
            PlayerPrefs.SetInt("sound", 0);
            sound = false;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            isFirst = false;
            PlayerPrefs.SetInt("sound", 1);
            Debug.Log("on");
            s.image.overrideSprite = onSound;
            sound = true;
        }

    }

    public void _play()
    {
        GameManager.instance.audio.Stop();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("test");
    }

    public void _extra()
    {
        GameManager.instance.audio.Stop();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("mode");
    }

    public void _level()
    {
        GameManager.instance.audio.Stop();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("level");

    }

    public void _shop()
    {
        GameManager.instance.audio.Stop();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("shop");
    }

}
