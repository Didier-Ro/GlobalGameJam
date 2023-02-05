using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanishStats : MonoBehaviour
{
  [SerializeField] private float _health = 100f;
  [SerializeField] private float _speed = 30f;
  [SerializeField] private int _regenRate = 50;
  [SerializeField] private float _speedRate = 2.5f;
  [SerializeField]  private int _cost = 30;
  [SerializeField] private int _deathAward = 2;
  [SerializeField] private int _damage = 40;

  public float Health => _health;
  public int RegenRate => _regenRate;
  public float Speed => _speed;
  public float SpeedRate => _speedRate;
}
