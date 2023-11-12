using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireExtinguisher : MonoBehaviour
{
    public InputActionReference foamTrigger;
    //var leftHandDevices = new UnityEngine.XR.InputDevice();
    //UnityEngine.XR.InputDevice.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
    //UnityEngine.XR.InputDevice.left


    //UnityEngine.XR.InputDevice device = leftHandDevices[0];


    //public LayerMask fireLayer;
    //private XRController xrController;
    public ParticleSystem foamParticles;
    //public GameObject[] flowerPrefabs;
    //public GameObject[] fireEffect;
    // Start is called before the first frame update
    private void Start()
    {
        //fireEffect = GameObject.FindGameObjectsWithTag("fire");


        //xrController = GetComponent<XRController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (foamTrigger.action.IsPressed())
        {
            StartExtinguishing();
            // Debug.Log("particles started spraying");

        }
        else
        {
            StopExtinguishing();
        }
        //if (xrController)
        //{
        //    // Check if the trigger button on the XR controller is pressed.
        //    if (xrController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerButtonPressed) && triggerButtonPressed)
        //    {
        //        StartExtinguishing();

        //    //if (Input.GetKey(KeyCode.F))
        //    //{
        //    //    StartExtinguishing();
        //    }
        //    else
        //    {
        //        StopExtinguishing();
        //    }
        //}
    }

    void StartExtinguishing()
    {
        if (foamParticles != null)
        {
            foamParticles.Play(); // Start the Particle System to simulate extinguishing.
            //if (fireEffect != null)
            //{
            //    fireEffect.SetActive(false); // Disable the fire effect GameObject.
            //}
        }
    }
    void StopExtinguishing()
    {
        if (foamParticles != null)
        {
            foamParticles.Stop();
        }
    }
    //void OnParticleCollision(GameObject other)
    //{
    //    // Check if the collision involves an object on the fireLayer
    //    if (fireLayer == (fireLayer | (1 << other.layer)))
    //    {
    //        // Handle the collision with fire (e.g., extinguish the fire)
    //        ExtinguishFire(other);
    //    }
    //}

    //void ExtinguishFire(GameObject fireObject)
    //{
    //    // Implement logic to extinguish the fire, e.g., disable the fireObject
    //    fireObject.SetActive(false);
    //    if (flowerPrefabs.Length > 0)
    //    {
    //        int _randomNumber = Random.Range(0, flowerPrefabs.Length);
    //        Instantiate(flowerPrefabs[_randomNumber], fireObject.transform.position, Quaternion.identity);
    //    }
    //}
    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.CompareTag("Fire"))
    //    {
    //        // Instantiate the half-burnt effect at the collision point.
    //        int _randomNumber = Random.Range(0, flowerPrefabs.Length);
    //        Instantiate(flowerPrefabs[_randomNumber], other.transform.position, Quaternion.identity);

    //        // Add additional logic if needed, such as reducing the intensity of the fire.
    //        // You can access the Fire script (if there is one) and modify its properties.

    //        // Destroy the original fire object.
    //        Destroy(other);
    //    }
    //}
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "fire")
        {
            Debug.Log("particle touched fire");
            GameObject currentFireObject = other.gameObject;
            Debug.Log("setting the game object");
            ForestFireCell cell = currentFireObject.GetComponent<ForestFireCell>();
            Debug.Log("setting the script to forest fire cell");
            if (cell.cellState == ForestFireCell.State.Alight) 
            {
            cell.SetBurnt(); // turning off the fire
            }
        }
       
                    //if ( other == fireEffect[0] || fireEffect[1])
                    //{
                    //    Destroy(fireEffect[0]); // Destroy the fire object when hit by extinguisher particles.
                    //    Destroy(fireEffect[0]);
                    //}
                    //if (other == fireEffect[0])
                    //{
                    //    Destroy(fireEffect[0]); // Destroy the fire object when hit by extinguisher particles.

                    //}
                    //if (other == fireEffect[1])
                    //{
                    //    Destroy(fireEffect[1]); // Destroy the fire object when hit by extinguisher particles.
                    //}
                }
}
