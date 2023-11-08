using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthKits : MonoBehaviour
{


    private PlayerHealth playerHealth; //script
    //private ForestFireCell healthKit;
    //private GameObject healthKit;
    public float healthKitValue; // customisable damage value for each colour
    private AudioSource healthSound;
   
    


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); // setting player health script
        healthSound = GameObject.FindGameObjectWithTag("Healthkit").GetComponent<AudioSource>(); // setting healthkit pickup sound
       
        //this.GetComponent<AudioSource>();
        //healthKit = GameObject.FindGameObjectsWithTag("Healthkit");
    }

  


    public void OnTriggerEnter(Collider other) // detecting when player goes through fire-effects' collider
    {
        if (other.tag == "Player" && playerHealth.currentHealth <= 100)
        {
            playerHealth.OnHealthPickUp(healthKitValue);
            healthSound.Play();
            Debug.Log("sound playing!");
          
            Destroy(gameObject);


            Debug.Log("The player current health is" + playerHealth.currentHealth);
        }
        else
        {
            Debug.Log("Not the player");
        }

    }
}
