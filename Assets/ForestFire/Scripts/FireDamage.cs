using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour

{
    private PlayerHealth playerHealth;
    public float damageValue;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.currentHealth = playerHealth.currentHealth - damageValue;
            Debug.Log("The player current health is" + playerHealth.currentHealth);
        }
        else
        {
            Debug.Log("Not the player");
        }
    }
}

