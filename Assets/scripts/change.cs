using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour {
    private SpriteRenderer sp;
    public static change instance;
    [System.Serializable]
    public class character
    {
        public Sprite s;
        public bool isChoose;
    }
    int index;
    public List<character> charac;

    // Use this for initialization
    void Start () {
        _MakeInstance();
        sp = GetComponent<SpriteRenderer>();
	}

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        _change();
    }

    void _change()
    {
        
        if(GameManager.instance._GetBall() == 0)
        {
            index = 0;
        }
        if (GameManager.instance._GetBall() == 200)
        {
            index = 1;
        }
        if (GameManager.instance._GetBall() == 250)
        {
            index = 2;
        }
        if (GameManager.instance._GetBall() == 300)
        {
            index = 3;
        }
        if (GameManager.instance._GetBall() == 350)
        {
            index = 4;
        }
        if (GameManager.instance._GetBall() == 400)
        {
            index = 5;
        }
        if (GameManager.instance._GetBall() == 450)
        {
            index = 6;
        }
        if (GameManager.instance._GetBall() == 500)
        {
            index = 7;
        }
        if (GameManager.instance._GetBall() == 550)
        {
            index = 8;
        }
        if (GameManager.instance._GetBall() == 600)
        {
            index = 9;
        }
        if (GameManager.instance._GetBall() == 650)
        {
            index = 10;
        }
        if (GameManager.instance._GetBall() == 700)
        {
            index = 11;
        }
        if (GameManager.instance._GetBall() == 750)
        {
            index = 12;
        }
        if (GameManager.instance._GetBall() == 800)
        {
            index = 13;
        }
        if (GameManager.instance._GetBall() == 850)
        {
            index = 14;
        }
        if (GameManager.instance._GetBall() == 900)
        {
            index = 15;
        }
        if (GameManager.instance._GetBall() == 950)
        {
            index = 16;
        }
        if (GameManager.instance._GetBall() == 1000)
        {
            index = 17;
        }
        if (GameManager.instance._GetBall() == 1100)
        {
            index = 18;
        }
        if (GameManager.instance._GetBall() == 1200)
        {
            index = 19;
        }
        sp.sprite = charac[index].s;
    }
}
