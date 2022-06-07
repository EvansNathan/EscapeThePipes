using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject collectable;
    public GameObject levelState;
    public int collectableIndex;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Collected!!");
            Destroy(collectable, 0);
            levelState.GetComponent<LevelState>().Collect(collectableIndex);
        }
    }
}
