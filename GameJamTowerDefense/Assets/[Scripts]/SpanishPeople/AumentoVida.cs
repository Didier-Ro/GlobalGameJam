using UnityEngine;
using System.Collections;


public class AumentoVida : MonoBehaviour
{

    [SerializeField] private int regenRate;
    SpanishStats spanishStats;
    [SerializeField] Health health;
    private void Awake()
    {
        spanishStats = GetComponent<SpanishStats>();
        regenRate = spanishStats.RegenRate;
    }
    private void Start()
    {
        health = GetComponent<Health>();
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
