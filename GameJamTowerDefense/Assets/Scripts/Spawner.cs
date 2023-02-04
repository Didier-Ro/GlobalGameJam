using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject minion;
    // Start is called before the first frame update
    void Start()
    {
       SpawnObject();
    }

    void SpawnObject()
    {
        Instantiate(minion, transform.position, Quaternion.identity);
    }
}
