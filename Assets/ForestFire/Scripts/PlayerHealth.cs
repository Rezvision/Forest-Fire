 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Slider healthSlider;
    public Image healthSliderFill;
    


    private bool shouldDisplayImage = false;
    private bool shouldDisplayDamageImage = false;

    private float displayTime = 0.6f;
    private float timer = 0.0f;
    public Image damageFilter;
    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("The starting health of the player is:" + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        //healthText.text = "Health:" + playerCurrentHealth;
        if (currentHealth >= (maxHealth / 100) * 50) // more than 50%
        {
            //healthText.color = Color.green;
            healthSliderFill.color = Color.green;

        }
        else if (currentHealth >= (maxHealth / 100) * 30 && currentHealth <= (maxHealth / 100) * 50) // between 30-50%
        {
           // healthText.color = Color.yellow;
            healthSliderFill.color = Color.yellow; 
        }
        else if (currentHealth >= (maxHealth / 100) * 0 && currentHealth <= (maxHealth / 100) * 30) // 0-30%
        {
           // healthText.color = Color.red;
            healthSliderFill.color = Color.red;
        }
        // if (ForestFireCell.State == ForestFireCell.State.Alight) // reducing health
        // currentHealth -= 10; 


        if (shouldDisplayImage)
        {
            healthImage.enabled = true;

            timer += Time.deltaTime;
            if (timer >= displayTime)
            {
                healthImage.enabled = false; // image component turned off
                shouldDisplayImage = false; // so the image is not diplayed all the time and ready for next time a health kit is picked up
                timer = 0.0f;
            }
        }
        if (shouldDisplayDamageImage)
        {
            damageFilter.enabled = true;

            timer += Time.deltaTime;
            if (timer >= displayTime)
            {
                damageFilter.enabled = false; // image component turned off
                shouldDisplayDamageImage = false; // so the image is not diplayed all the time and ready for next time the player is damaged
                timer = 0.0f;
            }
        }

    }

    public void OnHealthPickUp(float healthkitValue) // healthkit increasing health and showing a green effect on the screen
    {
        if (currentHealth + healthkitValue <= maxHealth) // only take health if the health won't go over max health
        {
        currentHealth += healthkitValue; 
        }
        else
        {
            currentHealth = maxHealth;// player's health cannot be more than 100
        }
        shouldDisplayImage = true;
        Debug.Log("green image shown");
    }

    public void FireDamage(float damageValue) // fire decrease health and showing a red effect on the screen
    {
        currentHealth -= damageValue;
        shouldDisplayDamageImage = true;
        Debug.Log("red image shown");
    }
}
