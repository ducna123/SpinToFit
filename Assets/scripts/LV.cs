using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LV : MonoBehaviour {
    public GameObject panelRate;
    public GameObject panelThanks;

    [System.Serializable]
    public class leve
    {
        public string levelText;
        public int Unlocked;
        public bool isInteractable;
        public bool isPass;
    }
    public int levelPlay;
    public List <leve> lv;
    public List<leve> lv2;
    public Button Button;
    public List<GameObject> spawn;
    public List<GameObject> spawn2;
    public GameObject panelBT;
    public GameObject panelLV;
    public static LV instance;
    public Transform pa;
    public Transform pb;
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject panelEW;
    public GameObject panelEL;
    public GameObject panelT;
    public GameObject panelBT2;
    public GameObject panelC;
    public Text coin;
    public Sprite unlock;
    public Text lb;
    public AudioClip win,lose;
    public AudioSource audio;
    public AudioClip click;
    public GameObject firework1;
    public GameObject firework2;
    public GameObject firework3;
    private GameObject camera;

    // Use this for initialization
    void Start() {
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
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        _MakeInstance();
        Time.timeScale = 1;
        //DeleteAll();                
        FillList();
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

    public void FillList()
    {
        for(int i = 1;i <= 48; i++)
        {
            //PlayerPrefs.SetInt("Level" + i, 1);
        }
        PlayerPrefs.SetInt("Level1", 1);
        
        foreach (var leve in lv)
        {
            Button newBT = Instantiate(Button) as Button;
            levelButton bt = newBT.GetComponent<levelButton>();
            bt.levelText.text = leve.levelText;
            //bt.transform.localScale = new Vector3(1, 1, 1);
            if(PlayerPrefs.GetInt("Level" + bt.levelText.text) == 1)
            {
                leve.Unlocked = 1;
                leve.isInteractable = true;
                newBT.image.overrideSprite = unlock;
                bt.panelT.SetActive(true);
                bt.locked.SetActive(false);
                bt.GetComponent<Button>().onClick.AddListener(() => loadLevel(int.Parse(bt.levelText.text.ToString())));
            }
            bt.unlocked = leve.Unlocked;
            //bt.GetComponent<Button>().interactable = leve.isInteractable;
            //Debug.Log(levelPlay);
            newBT.transform.SetParent(pa);
            newBT.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        foreach (var leve in lv2)
        {
            Button newBT = Instantiate(Button) as Button;
            levelButton bt = newBT.GetComponent<levelButton>();
            bt.levelText.text = leve.levelText;
            //bt.transform.localScale = new Vector3(1, 1, 1);
            if (PlayerPrefs.GetInt("Level" + bt.levelText.text) == 1)
            {
                leve.Unlocked = 1;
                leve.isInteractable = true;
                newBT.image.overrideSprite = unlock;
                bt.panelT.SetActive(true);
                bt.locked.SetActive(false);
                bt.GetComponent<Button>().onClick.AddListener(() => loadLevel2(int.Parse(bt.levelText.text.ToString())));
            }
            bt.unlocked = leve.Unlocked;
            //bt.GetComponent<Button>().interactable = leve.isInteractable;
            //Debug.Log(levelPlay);
            newBT.transform.SetParent(pb);
            newBT.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        SaveAll();
    }

    void SaveAll()
    {
        //if (PlayerPrefs.HasKey("Level1"))
        //{
         //   return;
        //}
        //else
        {
            GameObject[] allBT = GameObject.FindGameObjectsWithTag("LevelBT");
            foreach (GameObject bts in allBT)
            {
                levelButton btn = bts.GetComponent<levelButton>();
                PlayerPrefs.SetInt("Level" + btn.levelText.text, btn.unlocked);
            }
        }       
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    

    public void _back()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("Menu");
    }

    public void _shop()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        SceneManager.LoadScene("shop");
    }

    public void _endGW()
    {
        
        panelEW.SetActive(true);
        Time.timeScale = 0;
    }


    public void _endGL()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(lose);
        }
        panelEL.SetActive(true);
        Time.timeScale = 0;
    }

    public void _delayendGW()
    {
        PlayerPrefs.SetInt("Level" + (levelPlay + 1), 1);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(win);
        }
        Instantiate(firework1, new Vector3(camera.transform.position.x-2,camera.transform.position.y+3,0), Quaternion.identity);
        Instantiate(firework2, new Vector3(camera.transform.position.x, camera.transform.position.y - 3, 0), Quaternion.identity);
        Instantiate(firework3, new Vector3(camera.transform.position.x + 2, camera.transform.position.y + 4, 0), Quaternion.identity);
        Invoke("_endGW", 3f);
    }

    public void _delayendGL()
    {
        Invoke("_endGL",1.5f);
    }

    public void _next()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        //string a = "Level" + ;
        PlayerPrefs.SetInt("Level"+ (levelPlay+1), 1);
        //Debug.Log(PlayerPrefs.GetInt("Level") + );
        FillList();
        SceneManager.LoadScene("level");
    }

    public void _replay()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelEL.SetActive(false);
        if(levelPlay <= 24)
        {
            player.transform.position = new Vector3(0.1f, 4f, 0);
            player.SetActive(true);
        }
        if (levelPlay > 24 && levelPlay <= 37)
        {
            player2.transform.position = new Vector3(0.1f, 4f, 0);
            player2.SetActive(true);
        }
        if (levelPlay > 37 && levelPlay <= 43)
        {
            player3.transform.position = new Vector3(0.1f, 4f, 0);
            player3.SetActive(true);
        }
        if (levelPlay > 43 )
        {
            player4.transform.position = new Vector3(0.1f, 4f, 0);
            player4.SetActive(true);
        }

        Time.timeScale = 1;
    }

    void loadLevel(int value)
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        coin.text = GameManager.instance._GetBestS() + "";
        levelPlay = value;
        Vector3 temp = spawn[value-1].transform.position;
        panelLV.SetActive(false);
        panelBT.SetActive(false);
        panelBT2.SetActive(false);
        panelC.SetActive(true);
        coin.text = GameManager.instance._GetBestS() + "";
        player.SetActive(true);
        Instantiate(spawn[value-1], temp, Quaternion.identity);
    }

    void loadLevel2(int value)
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        coin.text = GameManager.instance._GetBestS() + "";
        levelPlay = value;
        Vector3 temp = spawn2[value - 25].transform.position;
        panelLV.SetActive(false);
        panelBT.SetActive(false);
        panelBT2.SetActive(false);
        panelC.SetActive(true);
        coin.text = GameManager.instance._GetBestS() + "";
        if (levelPlay > 24 && levelPlay <= 37)
        {
            player2.SetActive(true);
        }
        if (levelPlay > 37 && levelPlay <= 43)
        {
            player3.SetActive(true);
        }
        if (levelPlay > 43)
        {
            player4.SetActive(true);
        }
        Instantiate(spawn2[value - 25], temp, Quaternion.identity);
    }

    public void _nextLV()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelBT.SetActive(false);
        panelBT2.SetActive(true);
        lb.text = "LEVEL 25-48";
    }

    public void _backLV()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        panelBT.SetActive(true);
        panelBT2.SetActive(false);
        lb.text = "LEVEL 1-24";
    }

    public void _setS(int star)
    {
        coin.text = star + "";
    }

}
