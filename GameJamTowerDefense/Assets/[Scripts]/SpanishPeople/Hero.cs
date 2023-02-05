using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    // Update is called once per frame
    void Update()
    {  
       
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
