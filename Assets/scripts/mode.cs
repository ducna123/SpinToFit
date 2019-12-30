using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void _up()
    {
        SceneManager.LoadScene("fallingUP");
    }

    public void _flip()
    {
        SceneManager.LoadScene("fliplop");
    }

    public void _temple()
    {
        SceneManager.LoadScene("templeFall");
    }

    public void _one()
    {
        SceneManager.LoadScene("OneSide");
    }

    public void _quick()
    {
        SceneManager.LoadScene("quickFlip");
    }

    public void _back()
    {
        SceneManager.LoadScene("Menu");
    }

}
