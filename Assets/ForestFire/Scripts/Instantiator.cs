using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject[] healthKitPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        var position = new Vector3(Random.Range(0.0f, 155.0f), 0, Random.Range(0.0f, 155.0f));
        for (int i = 0; i < healthKitPrefabs.Length; i++) 
        {
            Instantiate(healthKitPrefabs[i], position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
