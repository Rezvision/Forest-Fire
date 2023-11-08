using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FireDamage : MonoBehaviour

{
    private PlayerHealth playerHealth;
    public float damageValue;
    private AudioSource damageSound;
   


 
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        damageSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other) // detecting when player goes through fire-effects' collider
    {
        if (other.tag == "Player" && playerHealth.currentHealth > 0)
        {
            playerHealth.FireDamage(damageValue);
            //playerHealth.currentHealth -= damageValue; // reducing health after touching fire
            damageSound.pitch = Random.Range(0.5f, 1.5f);
            damageSound.Play();
            
            Debug.Log("The player current health is" + playerHealth.currentHealth);
        }
        else
        {
            Debug.Log("Not the player");
        }
    }
}

