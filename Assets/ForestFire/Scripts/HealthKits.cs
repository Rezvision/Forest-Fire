using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKits : MonoBehaviour
{
    private PlayerHealth playerHealth;
    //private ForestFireCell healthKit;
    //private GameObject healthKit;
    public float healthKitValue;
    private AudioSource healthSound;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthSound = GameObject.FindGameObjectWithTag("Healthkit").GetComponent<AudioSource>();
            //this.GetComponent<AudioSource>();
        //healthKit = GameObject.FindGameObjectsWithTag("Healthkit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthSound.Play();
            Debug.Log("sound playing!");
            playerHealth.currentHealth += healthKitValue;
            Destroy(gameObject);

            Debug.Log("The player current health is" + playerHealth.currentHealth);
        }
        else
        {
            Debug.Log("Not the player");
        }
        
    }
}
