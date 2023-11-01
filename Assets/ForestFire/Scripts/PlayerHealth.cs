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
        if (currentHealth >= (maxHealth / 100) * 50)
        {
            //healthText.color = Color.green;
            healthSliderFill.color = Color.green;

        }
        else if (currentHealth >= (maxHealth / 100) * 30 && currentHealth <= (maxHealth / 100) * 50)
        {
           // healthText.color = Color.yellow;
            healthSliderFill.color = Color.yellow;
        }
        else if (currentHealth >= (maxHealth / 100) * 0 && currentHealth <= (maxHealth / 100) * 30)
        {
           // healthText.color = Color.red;
            healthSliderFill.color = Color.red;
        }
        // if (ForestFireCell.State == ForestFireCell.State.Alight) // reducing health
        // currentHealth -= 10; 
    }
}
