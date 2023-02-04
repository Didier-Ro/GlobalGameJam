using UnityEngine;

public class MenuData : MonoBehaviour
{
    [SerializeField] private float _preparationTime = 15f;
    [SerializeField] private float _roundDuration = 60f;
    [SerializeField] private int _rounds = 3;

    public int Rounds => _rounds;
    public float RoundDuration => _roundDuration;
    public float PreparationTime => _preparationTime;
    
}
