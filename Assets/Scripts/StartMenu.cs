using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string levelName;
    public bool transition = false;
   public void StartGame()
   {
       
       MusicManager.instance.Load(levelName, transition);

   }
}
