using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr;
    [SerializeField] private Sprite pressedSprite;
    private bool isPressed = false;
    public GameObject[] connectedObject;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.collider.CompareTag("Player") || isPressed) return;
        
        Debug.Log("ButtonPressed!");
        sr.sprite = pressedSprite;
        isPressed = true;

        foreach (var thing in connectedObject)
        {
            thing.GetComponent<FlameShooter>().Stop();
        }
    }
}
