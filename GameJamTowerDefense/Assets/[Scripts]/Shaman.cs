using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shaman : MonoBehaviour
{
    [SerializeField] private Transform _enemy = default;
    [SerializeField] private GameObject _shamanAOE;
    GameObject shaman;
    private void Start()
    {
        shaman = gameObject;
        shaman.transform.position += new Vector3(0, 15, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if(_enemy==null&&other.CompareTag("Espanol"))
        {
            _enemy = other.transform;
            StartCoroutine(ShamanAOE());
        }
    }

    IEnumerator ShamanAOE()
    {
        Instantiate(_shamanAOE, _enemy.position, Quaternion.identity);
        yield return new WaitForSeconds(4.5f);
        _enemy = null;
    }
}
