using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private const string best = "High";
    private const string bestU = "HighU";
    private const string bestF = "HighF";
    private const string bestO = "HighO";
    private const string bestT = "HighT";
    private const string bestQ = "HighQ";
    private const string star = "coin";
    private const string character = "ball";
    public AudioSource audio;
    public Button s;
    public Sprite onSound;
    public Sprite offSound;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        _MakeSingleInstance();
        //_SetBestS(1000);
        //PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(PlayerPrefs.GetInt("sound") == 0)
        {

            if(audio.isPlaying == true)
            {
                audio.Stop();
            }
            s.image.overrideSprite = offSound;
        }
        else if (PlayerPrefs.GetInt("sound") == 1)
        {
            if(audio.isPlaying == false)
            {
                audio.Play();
            }
            s.image.overrideSprite = onSound;
        }
    }

    void _FirstTime()
    {
        if (!PlayerPrefs.HasKey("_FirstTime"))
        {
            PlayerPrefs.SetInt(best, 0);
            PlayerPrefs.SetInt(bestU, 0);
            PlayerPrefs.SetInt(bestF, 0);
            PlayerPrefs.SetInt(bestO, 0);
            PlayerPrefs.SetInt(bestT, 0);
            PlayerPrefs.SetInt(bestQ, 0);
            PlayerPrefs.SetInt(character, 0);
            PlayerPrefs.SetInt(star, 0);
            PlayerPrefs.SetInt("_FirstTime", 0);
        }
    }

    void _MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    public void _SetBest(int point)
    {
        PlayerPrefs.SetInt(best, point);
    }
    //mode mac dinh
    public int _GetBest()
    {
        return PlayerPrefs.GetInt(best);
    }

    public void _SetBestU(int point)
    {
        PlayerPrefs.SetInt(bestU, point);
    }
    // mode flyhigh
    public int _GetBestU()
    {
        return PlayerPrefs.GetInt(bestU);
    }

    public void _SetBestF(int point)
    {
        PlayerPrefs.SetInt(bestF, point);
    }
    //mode fliplop
    public int _GetBestF()
    {
        return PlayerPrefs.GetInt(bestF);
    }

    public void _SetBestO(int point)
    {
        PlayerPrefs.SetInt(bestO, point);
    }
    //mode one side
    public int _GetBestO()
    {
        return PlayerPrefs.GetInt(bestO);
    }

    public void _SetBestQ(int point)
    {
        PlayerPrefs.SetInt(bestQ, point);
    }
    //mode temple
    public int _GetBestT()
    {
        return PlayerPrefs.GetInt(bestT);
    }

    public void _SetBestT(int point)
    {
        PlayerPrefs.SetInt(bestT, point);
    }
    //mode quick
    public int _GetBestQ()
    {
        return PlayerPrefs.GetInt(bestQ);
    }
    
    public void _SetBestS(int starT)
    {
        PlayerPrefs.SetInt(star, starT);
    }
    // get heart
    public int _GetBestS()
    {
        return PlayerPrefs.GetInt(star);
    }

    public int _getLevelPass()
    {
        int d = 0;
        for(int i = 1; i <= 48; i++)
        {
            if(PlayerPrefs.GetInt("Level"+i) == 1)
            {
                d++;
            }
        }
        d -= 1;
        return d;
    }

    public void _SetBall(int index)
    {
        PlayerPrefs.SetInt(character, index);
    }

    public int _GetBall()
    {
        return PlayerPrefs.GetInt(character);
    }
}
