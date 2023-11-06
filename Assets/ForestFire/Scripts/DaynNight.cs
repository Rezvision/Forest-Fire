using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
//using Unity.VisualScripting;
using UnityEngine;



public class DaynNight : MonoBehaviour
{
    public GameObject sun;
    public float cycleDuration = 600.0f; // 10 minutes in seconds
    private float elapsedTime = 0.0f;

    void Start()
    {
        sun = GameObject.FindGameObjectWithTag("sun");

    }

    void DayNight()
    {
        if (sun != null)
        {
            elapsedTime += Time.deltaTime;
            float rotationAngle = Mathf.Lerp(0f, 360f, elapsedTime / cycleDuration); // Gradual rotation

            sun.transform.rotation = Quaternion.Euler(rotationAngle, 0, 0);

            if (elapsedTime >= cycleDuration) //  timer is restarted (new day)[issa new day, issa new dawn!]
            {
                elapsedTime = 0.0f;
            }
        }
    }

    void Update()
    {
        DayNight();
    }
}

