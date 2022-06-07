using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public string levelName;
    
   public void EndGame()
   {
       MusicManager.instance.Load(levelName, false);
   }
   public void Credits(){
       MusicManager.instance.Load(levelName, false);
   }
}
