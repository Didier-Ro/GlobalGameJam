using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    public Transform[] waypoint;

    private void Awake()
    {
        waypoint = GetComponentsInChildren<Transform>();
    }

}
