using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public string levelName;

    void Start()
    {
        MusicManager.instance.Load(levelName, false);
    }
}