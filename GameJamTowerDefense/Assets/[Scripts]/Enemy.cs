using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    [SerializeField] private float movementSpeed = 4;
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed = 6;
    [SerializeField] private int cont;
    SpanishStats spanishStats;
    LineDetection lineDetection;

    private void Start()
    {
        spanishStats = GetComponent<SpanishStats>();
        lineDetection = GetComponent<LineDetection>();
        movementSpeed = spanishStats.Speed;
        target = lineDetection.target;
        lineDetection.enabled = false;
        for (int i = 0; i < target.GetComponent<Paths>().waypoint.Length; i++)
        {
            waypoints.Add(target.GetComponent<Paths>().waypoint[i]);
        }
    }
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
                Debug.Log(waypoints[targetIndex].position);
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
