using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject levelState;
    public GameObject endPoint;
    public string levelName;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            levelState.GetComponent<LevelState>().EndLevel();
            Destroy(endPoint, 0);
            MusicManager.instance.Load(levelName, true);
        }
    }
}
