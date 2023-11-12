using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireDamage : MonoBehaviour

{
    private PlayerHealth playerHealth;
    public float damageValue;
    private AudioSource damageSound;
    private VisualEffect fire;
    //private GameObject fireObject;
    public GameObject[] flowerPrefabs;




    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        damageSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        fire = GetComponent<VisualEffect>();
        //fireObject = GameObject.FindGameObjectWithTag("fire");

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
            Debug.Log("Not the player" + other.tag);
            if (flowerPrefabs.Length > 0)
            {
                Debug.Log("flower prefabs has been set!"+ flowerPrefabs.Length);
                int _randomNumber = Random.Range(0, flowerPrefabs.Length);
                Instantiate(flowerPrefabs[_randomNumber], this.transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
            Debug.Log("particle touched fire");
            fire.Stop();
            if (flowerPrefabs.Length > 0)
            {
                int _randomNumber = Random.Range(0, flowerPrefabs.Length);
                Instantiate(flowerPrefabs[_randomNumber], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No flower prefabs assigned!");
            }
            
            gameObject.SetActive(false); // Disable the entire fire GameObject 

        
    }
}
