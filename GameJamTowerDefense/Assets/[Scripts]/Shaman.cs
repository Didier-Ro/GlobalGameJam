using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shaman : MonoBehaviour
{
    [SerializeField] private Transform _enemy = default;
    [SerializeField] private GameObject _shamanAOE;

    private void OnTriggerStay(Collider other)
    {
        if(_enemy==null&&other.CompareTag("Enemy"))
        {
            _enemy = other.transform;
            StartCoroutine(ShamanAOE());
        }
    }

    IEnumerator ShamanAOE()
    {
        Instantiate(_shamanAOE, _enemy.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        _enemy = null;
    }
}
