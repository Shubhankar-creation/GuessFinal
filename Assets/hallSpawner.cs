using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallSpawner : MonoBehaviour
{

    public GameObject hallPrefab;

    private float k = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hall"))
        {
            Destroy(other.gameObject);
            GameObject newHall = Instantiate(hallPrefab, new Vector3(0f, 0f, 64 + k), Quaternion.identity);
            k += 16f;
        }
    }
}
