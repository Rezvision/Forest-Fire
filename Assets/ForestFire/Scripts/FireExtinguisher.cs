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



    //private XRController xrController;
    public ParticleSystem foamParticles;
    public GameObject[] fireEffect;
    // Start is called before the first frame update
    private void Start()
    {
        //fireEffect = GameObject.FindGameObjectsWithTag("fire");
        fireEffect = GameObject.FindGameObjectsWithTag("fire");

        //xrController = GetComponent<XRController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (foamTrigger.action.IsPressed())
        {
            StartExtinguishing();
            Debug.Log("particles started spraying");

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
    private void OnParticleCollision(GameObject other)
        {
            if (other.tag == "fire")
            {
                GameObject currentFireObject = other.gameObject;
                Debug.Log("setting the game object");
                ForestFireCell cell = currentFireObject.GetComponent<ForestFireCell>();
                Debug.Log("setting the script");
                cell.SetBurnt();
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
