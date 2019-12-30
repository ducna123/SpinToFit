using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onecontroller : MonoBehaviour {
    public GameObject panelRate;
    public GameObject panelThanks;

    public static onecontroller instance;
    [SerializeField]
    private Text scoreT, endScoreT, bestT;

    [SerializeField]
    private GameObject panelEnd;
    // Use this for initialization
    public GameObject p1;
    public GameObject p2;
    void Start()
    {
        if (PlayerPrefs.GetInt("rate") == 0)
        {
            float x = Random.Range(1, 10);
            if (x == 5)
            {
                panelRate.SetActive(true);
                //Time.timeScale = 0;
                Invoke("_time", 0.5f);
            }
        }
    }

    void _time()
    {
        Time.timeScale = 0;
    }

    public void _rateNow()
    {
        PlayerPrefs.SetInt("rate", 1);
        panelRate.SetActive(false);
        panelThanks.SetActive(true);
    }

    public void _later()
    {
        panelRate.SetActive(false);
        Time.timeScale = 1;
    }

    public void _ok()
    {
        panelThanks.SetActive(false);
        Time.timeScale = 1;
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Awake()
    {
        Time.timeScale = 1;
        _MakeInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void endG()
    {
        Time.timeScale = 0;
        panelEnd.SetActive(true);
        endScoreT.text = playerOne.instance.point + "";
        if (playerOne.instance.point > GameManager.instance._GetBestO())
        {
            GameManager.instance._SetBestO(playerOne.instance.point);
        }
        bestT.text = "" + GameManager.instance._GetBestO();
    }

    public void delayendG()
    {
        Invoke("endG",1);
    }

    public void _reS()
    {
        SceneManager.LoadScene("OneSide");
        Time.timeScale = 1;
    }

    public void _setP(int point)
    {
        scoreT.text = point + "";
    }

    public void _home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _shop()
    {
        SceneManager.LoadScene("shop");
    }

}
