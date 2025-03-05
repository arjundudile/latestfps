using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreBlast : MonoBehaviour
{
    public GameObject[] gores; // Assign gore prefabs in Inspector
    public int count;

    void Start()
    {
        if (gores == null || gores.Length == 0)
        {
            Debug.LogError("GoreBlast: No gore prefabs assigned!");
            return; // Prevents execution if no prefabs are assigned
        }

        for (int i = 0; i < count; i++)
        {
            GameObject _gore = Instantiate(gores[Random.Range(0, gores.Length)], transform.position, Random.rotation);
            
            Rigidbody rb = _gore.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = new Vector3(Random.Range(-50, 50), Random.Range(20, 100), Random.Range(-50, 50));
                rb.AddForce(force, ForceMode.Impulse); // Impulse force for better effect
            }
            else
            {
                Debug.LogWarning("GoreBlast: Instantiated gore object missing Rigidbody!");
            }
        }
    }
}
