using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    // Start is called before the first frame update

    public bool[] collectables = {false, false, false};
    
    public void Collect(int index)
    {
        collectables[index] = true;
        
        Debug.Log(collectables[0] + ", " + collectables[1] + ", " + collectables[2]);
    }

    public void EndLevel()
    {
        Debug.Log("END LEVEL!");
    }
}
