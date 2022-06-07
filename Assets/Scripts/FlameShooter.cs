using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameShooter : MonoBehaviour
{

    [SerializeField] private Slider slider;
    public float damage;
    [SerializeField] private ParticleSystem ps;
    private BoxCollider2D bc2d;
    public bool isHealer;
    private bool isHit = false;

    private void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

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
        if (other.CompareTag("Player") && !isHit && !isHealer)
        {
            slider.GetComponent<ProgressBar>().ChangeSliderProgress(-damage);
            isHit = true;
            //Debug.Log("Enter");
        }
        else if (other.CompareTag("Player") && !isHit && isHealer)
        {
            slider.GetComponent<ProgressBar>().targetProgress = 1f;
            Destroy(GetComponent<BoxCollider2D>());
            ps.Stop();
        }
    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isHit = false;
        //Debug.Log("Exit");
    }

    public void Stop()
    {
        ps.Stop();
        bc2d.enabled = !bc2d.enabled;
    }

}
