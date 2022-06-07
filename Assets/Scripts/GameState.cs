using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Slider waterSlider;
    public GameObject playerDeathComponent;

    public void UpdateWaterSlider(float value)
    {

        if (value <= 0)
        {
            playerDeathComponent.GetComponent<PlayerDeath>().Death();
        }
    }

}
