using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{
    public static RoundManager RoundInstance { get; private set; }
    [SerializeField] private float _timeleft;
    [SerializeField] private float _time;
    public bool AttackerTurn = false;
    public bool DefenderTurn = true;
    public int _roundLeft = default;
    public float player1Streak = 0;
    public float player2Streak = 0;
    [SerializeField] private float _phaseTimer = 0;
    [SerializeField] private AudioClip[] _sfxSounds = null;
    [SerializeField] private TextMeshProUGUI textTime = default;
    [SerializeField] private TextMeshProUGUI GoldText = default;
    private MenuData _menuData;
    [SerializeField] private CineMachineSwitcher cineMachineSwitcher = null;

    private void Awake()
    {
        if (RoundInstance == null)
        {
            RoundInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _menuData = GetComponent<MenuData>();
        _timeleft = _menuData.PreparationTime;
        _time = _menuData.PreparationTime;
        ResetAll();
        _roundLeft = _menuData.Rounds;
        _phaseTimer = 0;
        AudioManager.instance.PlaySFX(_sfxSounds[0]);
    }

    void Update()
    {
        if (GameManager.Instance.PlayerActualHealth < 0 && _roundLeft > 6)
        {
            GameManager.Instance.Player2Score += 10 - _roundLeft;
            ResetAll();
        }
        else if (GameManager.Instance.PlayerActualHealth < 0 && _roundLeft < 6)
        {
            GameManager.Instance.Player1Score += _roundLeft;
            ResetAll();
        }
        if (_phaseTimer == 0)
        {
            if (_timeleft > 0)
            {
                _timeleft -= Time.deltaTime;
            }
            else
            {
                AttackerTurn = true;
                DefenderTurn = false;
                Debug.Log("si paso");
                _timeleft = _menuData.PreparationTime;
                _phaseTimer = 1;
                cineMachineSwitcher.SwitchCamera();
            }
             textTime.text = _timeleft.ToString("0");
            if (_roundLeft > 5)
            {
                GoldText.text = GameManager.Instance.Player1Gold.ToString("0");
            }
            else
            {
                GoldText.text = GameManager.Instance.Player2Gold.ToString("0");
            }
        }
        else if (_phaseTimer == 1)
        {
            AttackTime();
            if (_roundLeft > 5)
            {
                GoldText.text = GameManager.Instance.Player2Gold.ToString("0");
            }
            else
            {
                GoldText.text = GameManager.Instance.Player1Gold.ToString("0");
            }
             textTime.text = _timeleft.ToString("0");
        }
        else if (_phaseTimer == 2)
        {
            GoldText.enabled = false;
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
            DefenderTurn = false;
            AttackerTurn= false;
            _timeleft = _menuData.RoundDuration;
            cineMachineSwitcher.SwitchCamera();
            _phaseTimer = 2; 
            GameObject[] activateAttackers = GameObject.FindGameObjectsWithTag("Espanol");
            if (activateAttackers != null)
            {
                foreach (var Troop in activateAttackers)
                {
                    Troop.GetComponent<Enemy>().enabled = true;
                    Troop.GetComponent<Health>().enabled = true;
                }
            }
            AudioManager.instance.PlaySFX(_sfxSounds[1]);
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
            GoldText.enabled = true;
            DefenderTurn = true;
            AttackerTurn = false;
            _timeleft = _menuData.PreparationTime;
            GameManager.Instance.WinnerCheck();
            GameManager.Instance.PlayerHealthRound = GameManager.Instance.PlayerActualHealth;
            cineMachineSwitcher.SwitchCamera();
            _phaseTimer = 0;
            AudioManager.instance.PlaySFX(_sfxSounds[0]);
        }
    }
    public void ResetAll()
    {
        GameManager.Instance.GoldReset();
        GameManager.Instance.PlayerActualHealth = 500;
    }
}