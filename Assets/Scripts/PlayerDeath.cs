using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    public GameObject playerMovementRef;
    public GameObject playerObj;
    public GameObject particles;
    public Image fadeToBlackImg;
    public Sprite[] deathSprites;
    private bool isFadingOut;
    private bool isFadingIn;
    private Animator anim;

    private void Awake()
    {
        anim = playerObj.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isFadingOut)
        {
            StartCoroutine(FadeToBlack());
            
        }
    }

    public void Death()
    {
        playerMovementRef.GetComponent<PlayerMovement>().isDead = true;
        //anim.SetTrigger("Death");
        Destroy(particles, 0);

        StartCoroutine(DeathAnim(.25f));

        Invoke("StartFadeOut", 2);
    }

    public IEnumerator FadeToBlack(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = fadeToBlackImg.color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while (fadeToBlackImg.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeToBlackImg.color = objectColor;
                yield return null;
            }
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartFadeOut()
    {
        isFadingOut = true;
        Invoke("Reset", 2);
    }

    private IEnumerator DeathAnim(float waitTime)
    {
       Destroy(playerObj.GetComponent<Animator>());
        
        int index = 0;
        while (index < 3)
        {
            playerObj.GetComponent<SpriteRenderer>().sprite = deathSprites[index];
            index++;
            yield return new WaitForSeconds(waitTime);
        }
        
        Destroy(playerObj.GetComponent<SpriteRenderer>());
    }
}
