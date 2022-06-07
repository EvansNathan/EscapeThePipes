using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private ParticleSystem progressParticles;
    public Camera mCamera;
    public float tickRate;
    public float tickDamage;
    public float fillSpeed = .5f;
    public float targetProgress;
    public GameObject gameState;
    public float magnitude;
    public float duration;
    
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        targetProgress = slider.value = 1f;
        Invoke("StartTick", 2);

    }

    private void Update()
    {
        UpdateProgressBar();
    }

    public void RefillHealth()
    {
        targetProgress = 1f;
        slider.value = 1f;
    }

    private void StartTick()
    {
        StartCoroutine(TickHealth());
    }

    public void ChangeSliderProgress(float amount)
    {
        targetProgress = targetProgress + amount;
        //StartCoroutine(Shake(duration, magnitude));
    }

    private void UpdateProgressBar()
    {
        if (slider.value > targetProgress)
        {
            slider.value -= fillSpeed * Time.deltaTime;
            if (!progressParticles.isPlaying)
            {
                progressParticles.Play();
            }

            if (targetProgress < 0)
            {
                targetProgress = 0;
            }
        }
        else if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!progressParticles.isPlaying)
            {
                progressParticles.Play();
            }
            
            if (targetProgress > 100)
            {
                targetProgress = 100;
            }
        }

        if (!(slider.value - targetProgress < .01) || !(slider.value - targetProgress > -.01)) return;
        slider.value = targetProgress;
        progressParticles.Stop();

        float value = slider.value;
        gameState.GetComponent<GameState>().UpdateWaterSlider(value);
    }

    private IEnumerator TickHealth(bool tickHealth = true)
    {
        while (tickHealth && targetProgress > 0)
        {
            ChangeSliderProgress(-tickDamage);
            yield return new WaitForSeconds(tickRate);
        }
    }

    private IEnumerator Shake(float dur, float mag)
    {
        Vector3 originalPos = mCamera.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < dur)
        {
            float xOffset = Random.Range(-.5f, .5f) * mag;
            float yOffset = Random.Range(-.5f, .5f) * mag;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
