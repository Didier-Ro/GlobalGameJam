using UnityEngine;
using System.Collections;

public class VelocidadAumento : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedrate;
    SpanishStats spanishStats;
    private void Awake()
    {
        spanishStats = new SpanishStats();
        speed = spanishStats.Health;
        speedrate = spanishStats.SpeedRate;
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
            speed += speedrate;
        }
    }

}