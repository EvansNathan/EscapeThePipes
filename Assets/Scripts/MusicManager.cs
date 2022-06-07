using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioClip mainMenu;
    public AudioClip levels;
    public AudioClip endScene;
    private string lastLevelName;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public void Load(string levelName, bool isLevelTransition)
    {
        SceneManager.LoadScene(levelName);
        lastLevelName = levelName;
        Time.timeScale = 1f;
        if (levelName == "Main Menu")
        {
            if(!isLevelTransition)
            {
                GetComponent<AudioSource>().clip = mainMenu;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (levelName == "End Screen")
        {
            Debug.Log("END");
            GetComponent<AudioSource>().clip = endScene;
            GetComponent<AudioSource>().volume = .15f;
            GetComponent<AudioSource>().Play();
        }
        else if (levelName == "SelectMenu" || levelName == "Credits" || levelName == "Credits 1")
        {
            
        }
        else
        {
            if (!isLevelTransition)
            {
                GetComponent<AudioSource>().clip = levels;
                GetComponent<AudioSource>().volume = .15f;
                GetComponent<AudioSource>().Play();
            }
        }


    }
}
