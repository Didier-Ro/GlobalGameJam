using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private Transform _weaponBarrel = default;
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private int _damagePower = 10;
    [SerializeField] private float _shootCoolDown = 1;
    [SerializeField] private UnityEvent OnShoot = default;
    [SerializeField] private LayerMask _enemyLayerMask = default;
    [SerializeField] private GameState _gameState = default;
    [SerializeField] private bool _isEnemyInRange = false;
    
    
    [SerializeField] private GameObject _cannonBallPrefab = default;
    [SerializeField] private Transform _cannonBallSpawn = default;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (_isEnemyInRange)
        {
            //Ray ray = new Ray(_cannonBallSpawn.position, _cannonBallSpawn.forward);
            RaycastHit hit;
            Debug.Log("Hit");
            if (Physics.Raycast(_cannonBallSpawn.position, _cannonBallSpawn.forward, out hit, 10))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.CompareTag("Enemy"))
                {
                    Instantiate(_cannonBallPrefab, _cannonBallSpawn.position, _cannonBallSpawn.rotation);
                    Debug.Log("Instantiate");
                    OnShoot?.Invoke();
                }
                yield return new WaitForSeconds(_shootCoolDown);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void IsEnemyInRange()
    {
        _isEnemyInRange = true;
    }

    public void IsEnemyOut()
    {
        _isEnemyInRange = false;
    }
}
