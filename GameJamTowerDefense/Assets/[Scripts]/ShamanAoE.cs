using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ShamanAoE : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    void Start()
    {
        Destroy(gameObject,.3f);
    }

    private void OnDestroy()
    {
 
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, 1,_targetMask );
        if (rangeChecks.Length != 0)
        {
            GameObject target = rangeChecks[0].gameObject;
            target.GetComponent<Health>().ReceiveDamage(120);
        }
    }
}
