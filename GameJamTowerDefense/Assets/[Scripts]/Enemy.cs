using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    private int targetIndex = 1;

    [SerializeField] private float movementSpeed = 4;

    [SerializeField] private float rotationSpeed = 6;
    
    // Update is called once per frame
    void Update()
    {
        Movement();
        LookAt();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        
        if (distance <= 0.1f)
        {
            if (targetIndex >= waypoints.Count - 1)
            {
                return;
            }

            targetIndex++;
        }
    }

    private void LookAt()
    {
        Vector3 dir = waypoints[targetIndex].position - transform.position;
        Quaternion rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
    }
}
