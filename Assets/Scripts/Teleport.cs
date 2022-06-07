using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] protected GameObject teleportTo;
    [SerializeField] protected Camera gameCamera;
    [SerializeField] protected Vector3 cameraJump;
    
    bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            other.transform.position = teleportTo.transform.position;
            gameCamera.transform.position = gameCamera.transform.position + cameraJump;
            isActive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isActive = true;
    }
}
