using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeleft;
    [SerializeField] private float _time;
    [SerializeField] private int _roundLeft = default;
    [SerializeField] private bool _timerOn = false;
    [SerializeField] private bool _defenseTurn = default;
    [SerializeField] private TextMeshProUGUI textTime = default;
    private MenuData _menuData;

    private void Start()
    {
        _menuData = GetComponent<MenuData>();
        _timeleft = _menuData.PreparationTime;
        _time = _menuData.PreparationTime;
        _roundLeft = _menuData.Rounds;
        _defenseTurn = true;
        _timerOn = false;
    }

    void Update()
    {
        if(_timerOn)
        {
            if (_timeleft > 0)
            {
                _timeleft -= Time.deltaTime;
            }
            else
            {
                _timeleft = _menuData.PreparationTime;
                _timerOn = false;
                if (!_defenseTurn)
                {
                    _roundLeft--;
                }
                _defenseTurn = !_defenseTurn;
            }
            textTime.text = _timeleft.ToString("0");
        }
        else
        {
            PreparationTime();
            textTime.text = _timeleft.ToString("0");
        }
    }

    private void PreparationTime()
    {
        if (_timeleft > 0)
        {
            _timeleft -= Time.deltaTime;
        }
        else
        {
            _timeleft = _menuData.RoundDuration;
            _timerOn = true;
        }
        
    }

}