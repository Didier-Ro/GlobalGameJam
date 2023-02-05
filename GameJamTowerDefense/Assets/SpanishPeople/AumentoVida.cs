using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoVida : MonoBehaviour
{
  
    [SerializeField] private int regenRate;
    SpanishStats spanishStats;
   [SerializeField] Health health;
    private void Awake()
    {
        spanishStats = new SpanishStats();
        regenRate = spanishStats.RegenRate;
    }
    private void Start()
    {
        StartCoroutine(RegenLife());
    }
    private IEnumerator RegenLife()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            health.ReceiveHealth(regenRate);
        }
    }
}
