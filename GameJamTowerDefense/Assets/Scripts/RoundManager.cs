using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{
    [SerializeField] private float _timeleft;
    [SerializeField] private float _time;
    public int _roundLeft = default;
    [SerializeField] private float _phaseTimer = 0;
    [SerializeField] private bool _defenseTurn = default;
    [SerializeField] private TextMeshProUGUI textTime = default;
    private MenuData _menuData;
    [SerializeField] private CineMachineSwitcher cineMachineSwitcher = null;

    private void Start()
    {
        _menuData = GetComponent<MenuData>();
        _timeleft = _menuData.PreparationTime;
        _time = _menuData.PreparationTime;
        _roundLeft = _menuData.Rounds;
        _defenseTurn = true;
        _phaseTimer = 0;
    }

    void Update()
    {
        if(_phaseTimer == 0)
        {
            if (_timeleft > 0)
            {
                _timeleft -= Time.deltaTime;
            }
            else
            {
                _timeleft = _menuData.PreparationTime;
                _phaseTimer = 1;
                cineMachineSwitcher.SwitchCamera();
            }
            textTime.text = _timeleft.ToString("0");
        }
        else if(_phaseTimer == 1)
        {
           AttackTime();
            textTime.text = _timeleft.ToString("0");
        }
       else if(_phaseTimer == 2){
           BattleTime();
            textTime.text = _timeleft.ToString("0");
        }
    }

    private void AttackTime()
    {
        if (_timeleft > 0)
        {
            _timeleft -= Time.deltaTime;
        }
        else
        {
            _timeleft = _menuData.RoundDuration;
            cineMachineSwitcher.SwitchCamera();
            _phaseTimer = 2;
        }
    }
    private void BattleTime()
    {
        if (_timeleft > 0)
        {
            _timeleft -= Time.deltaTime;
        }
        else
        {
            _time = _menuData.PreparationTime;
            cineMachineSwitcher.SwitchCamera();
            _phaseTimer = 0;
        }
    }
}
