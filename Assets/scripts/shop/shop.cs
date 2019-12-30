using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour {
    [System.Serializable]
    public class person
    {
        public string cost;
        public int Unlocked;
        public bool isInteractable;
        public bool isChoose;
    }
    public static shop instance;
    public List <person> character;
    public Transform pa;
    public Text star;
    public Button Button;
    public List<Sprite> ima;
    public List<Sprite> unlock;
    public GameObject choose;
    public static Vector3 temp;
    public static bool first;
    public GameObject notice;
    public GameObject notice2;
    public AudioSource audio;
    public AudioClip click;

    // Use this for initialization


    void Start () {
        if(PlayerPrefs.GetInt("first") == 0)
        {
            first = false;
            PlayerPrefs.SetInt("first", 1);
        }
        else if(PlayerPrefs.GetInt("first") == 1)
        {
            first = true;
        }
        star.text = GameManager.instance._GetBestS() + "";
        if(first == false )
        {
            choose.transform.position = new Vector3(-2f, 2.45f, 0);
            first = true;
        }
        else if(first == true)
        {
            temp.x = PlayerPrefs.GetFloat("tempx");
            temp.y = PlayerPrefs.GetFloat("tempy");
            temp.z = PlayerPrefs.GetFloat("tempz");
            choose.transform.position = temp;
        }
        FillList();
        _MakeSingleInstance();
        //DestroyAll();
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

    void FillList()
    {
        PlayerPrefs.SetInt("Button0", 1);
        int i = 0;
        foreach (var person in character)
        {         
            Button newBT = Instantiate(Button) as Button;
            shopButton bt = newBT.GetComponent<shopButton>();
            bt.cost.text = person.cost;
            if (PlayerPrefs.GetInt("Button" + bt.cost.text) == 1)
            {
                person.Unlocked = 1;
                person.isInteractable = true;
                newBT.image.overrideSprite = unlock[i];
                bt.panelCost.SetActive(false);
            }
            else
            {
                newBT.image.overrideSprite = ima[i];
            }
            bt.unlocked = person.Unlocked;
            if(person.Unlocked == 0)
            {
                bt.GetComponent<Button>().onClick.AddListener(() => buy(int.Parse(person.cost)));
            }
            if(person.Unlocked == 1)
            {
                bt.GetComponent<Button>().onClick.AddListener(() => Choose(newBT,int.Parse(person.cost)));
                temp = newBT.transform.position;
            }
            newBT.transform.SetParent(pa);
            newBT.transform.localScale = new Vector3(1, 1, 1);
            i++;
        }
        SaveAll();
    }

    void SaveAll()
    {
        GameObject[] allBT = GameObject.FindGameObjectsWithTag("shop");
        foreach (GameObject bts in allBT)
        {
            shopButton btn = bts.GetComponent<shopButton>();
            PlayerPrefs.SetInt("shop" + btn.cost.text, btn.unlocked);
        }
    }

    void Choose(Button bt,int index)
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        choose.transform.position = bt.transform.position;
        temp = choose.transform.position;
        GameManager.instance._SetBall(index);
        PlayerPrefs.SetFloat("tempx", temp.x);
        PlayerPrefs.SetFloat("tempy", temp.y);
        PlayerPrefs.SetFloat("tempz", temp.z);
        //DontDestroyOnLoad(choose);
    }

    void DestroyAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void buy(int cost)
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        Debug.Log(cost);
        int coin = GameManager.instance._GetBestS();
        Debug.Log(coin);
        if (coin >= cost)
        {
            Debug.Log("mua");
            PlayerPrefs.SetInt("Button"+cost, 1);
            GameManager.instance._SetBestS(coin - cost);
            SceneManager.LoadScene("shop");
            temp = choose.transform.position;
        }
        else if(cost > coin)
        {
            notice.SetActive(true);
        }
    }

    public void _OK()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        notice.SetActive(false);
    }

    public void _OK2()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        notice2.SetActive(false);
    }

    public void _30heart()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        int x = GameManager.instance._GetBestS();
        x += 30;
        GameManager.instance._SetBestS(x);
        //SceneManager.LoadScene("shop");
        star.text = GameManager.instance._GetBestS() + "";
        notice.SetActive(false);
        notice2.SetActive(true);
    }

    

    public void _home()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
        temp = choose.transform.position;
        SceneManager.LoadScene("Menu");
    }
}
