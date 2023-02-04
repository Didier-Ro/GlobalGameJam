using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeleft;
    [SerializeField] private float _time;
    private bool _onPause = false;
    private bool _defenseTurn = default;
    [SerializeField] private TextMeshProUGUI textTime = default;
    private MenuData _menuData;

    private void Start()
    {
        _menuData = GetComponent<MenuData>();
        _time = _menuData.GetComponent<MenuData>().PreparationTime;
        DefenseTurn();
    }

    void Update()
    {
        if(!_onPause)
        {
            _time -= Time.deltaTime;
            textTime.text = _time.ToString("0");
            if (_timeleft <= 0)
            {
              AttackTurn();  
            }
        }
    }

    private void DefenseTurn()
    {
        _defenseTurn = true;
    }

    private void AttackTurn()
    {
        _defenseTurn = false;
    }
}
