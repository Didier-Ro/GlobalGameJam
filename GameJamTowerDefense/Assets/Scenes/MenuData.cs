using UnityEngine;

public class MenuData : MonoBehaviour
{
    [SerializeField] private float _preparationTime = 15f;
    [SerializeField] private int _rounds = 3;

    public float Rounds => _rounds;
    public float PreparationTime => _preparationTime;
    
}
