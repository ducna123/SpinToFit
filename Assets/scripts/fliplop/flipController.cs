using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class flipController : MonoBehaviour {
    public GameObject panelRate;
    public GameObject panelThanks;

    public static flipController instance;
    [SerializeField]
    private Text scoreT, endScoreT, bestT;

    [SerializeField]
    private GameObject panelEnd;
    // Use this for initialization
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
    public void _setP(int point)
    {
        scoreT.text = point + "";
    }
    
    public void endG()
    {
        Time.timeScale = 0;
        panelEnd.SetActive(true);
        endScoreT.text = playerFlip.instance.point + "";
        if(GameManager.instance._GetBestF() < playerFlip.instance.point)
        {
            GameManager.instance._SetBestF(playerFlip.instance.point);
        }
        bestT.text = GameManager.instance._GetBestF() + "";
    }

    public void delayendG()
    {
        Invoke("endG",1.5f);
    }

    public void _reS()
    {
        SceneManager.LoadScene("fliplop");
        Time.timeScale = 1;
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
