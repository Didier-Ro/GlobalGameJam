using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private LayerMask _targetMask;
    private int targetIndex = 1;
    [SerializeField] private float movementSpeed = 4;

    [SerializeField] private float rotationSpeed = 6;
    [SerializeField] private int cont;
    
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

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(RegenHp());
    }

    IEnumerator RegenHp()
    {

        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, 1,_targetMask );
        if (rangeChecks.Length != 0)
        {
            for (int i = 0; i < rangeChecks.Length-1; i++)
            {
                
                GameObject target = rangeChecks[i].gameObject;
                var hero = target.GetComponent<Health>();
                if(hero != null) hero.HeroShield();
            }
        }
        yield return new WaitForSeconds(1.5f);
    }
}
