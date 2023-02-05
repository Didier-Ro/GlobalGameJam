using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealt = 100;
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private UnityEvent<int> OnReceiveDamage;
    [SerializeField] private UnityEvent OnZeroHealth;
    SpanishStats spanishStats;

    private void Awake()
    {
        spanishStats = GetComponent<SpanishStats>();
    }

    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public void ReceiveDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        OnReceiveDamage?.Invoke(_currentHealth);
        if (CurrentHealth <= 0)
        {
            OnZeroHealth?.Invoke();
        }
    }
    public void ReceiveHealth(int healthAmount)
    {
        CurrentHealth += healthAmount;
    }

    private void OnEnable()
    {
        //_maxHealt = spanishStats.Health;
        _currentHealth = _maxHealt;
    }
    public void HeroShield()
    {
        CurrentHealth += 150;
    }
    
}