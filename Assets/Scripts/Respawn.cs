using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject respawnPoint;
    public GameObject player;
    public Slider slider;

    public void respawn()
    {
        player.transform.position = respawnPoint.transform.position;
        slider.value = 1f;
        slider.GetComponent<ProgressBar>().targetProgress = 1f;
    }
}
