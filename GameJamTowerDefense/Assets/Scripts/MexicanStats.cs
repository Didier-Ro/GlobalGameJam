using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanStats : MonoBehaviour
{
   [SerializeField] private float _fireRate = 2f;
    [SerializeField]private float _range = 30f;
   [SerializeField] private float _cost = 30f;
    [SerializeField] private float _damage = 80;

    public float FireRate => _fireRate;
    public float Range => _range;
    public float Cost => _cost;
    public float Damage => _damage;
}
