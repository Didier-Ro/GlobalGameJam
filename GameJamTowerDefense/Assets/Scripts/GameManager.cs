using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private float _timeSpeed = 1;
    [SerializeField] private UnityEvent OnGameOver = default;
    [SerializeField] private AudioClip _backgroundMusic = null;
    [SerializeField] private GameState _gameState = default;
    [SerializeField] private GameObject _AttackerUI = default;
    [SerializeField] private GameObject _DefenderUI = default;
    [SerializeField] private GameObject _piramide = default;
    [SerializeField] private GameObject _panel = default;
    public float Player1Score = default;
    public float Player2Score = default;
    public float PlayerHealthRound = default;
    public float PlayerActualHealth = default;
    public float Player1Gold = default;
    public float Player2Gold = default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic(_backgroundMusic);
    }
    private void Update()
    {
        PlayerActualHealth = _piramide.GetComponent<Health>().CurrentHealth;
        if (RoundManager.RoundInstance.DefenderTurn)
        {
            _DefenderUI.SetActive(true);
            _AttackerUI.SetActive(false);
        }
        else if(RoundManager.RoundInstance.AttackerTurn) 
        { 
            _AttackerUI.SetActive(true);
            _DefenderUI.SetActive(false);
        }
        else
        {
            _AttackerUI.SetActive(false);
            _DefenderUI.SetActive(false);
        }
    }


    private void OnEnable()
    {
        _gameState.CurrentGameState = GameState.GameStateEnum.Playing;
    }

    public void AddScorePlayer1(float goldValue)
    {
        Player1Gold += goldValue;
    }
    public void AddScorePlayer2(float goldValue)
    {
        Player2Gold += goldValue;
    }
    public void WinnerCheck()
    {
        if (RoundManager.RoundInstance._roundLeft > 5 && PlayerHealthRound - PlayerActualHealth >= 100)
        {
            RoundManager.RoundInstance.player1Streak = 0;
            RoundManager.RoundInstance.player2Streak++;
            Player2Wins();
        }
        else if (RoundManager.RoundInstance._roundLeft > 5 && PlayerHealthRound - PlayerActualHealth < 100)
        {
            RoundManager.RoundInstance.player2Streak = 0;
            RoundManager.RoundInstance.player1Streak++;
            Player1Wins();
        }
        if (RoundManager.RoundInstance._roundLeft <= 5 && PlayerHealthRound - PlayerActualHealth >= 100)
        {
            RoundManager.RoundInstance.player2Streak = 0;
            RoundManager.RoundInstance.player1Streak++;
            Player1Wins();
        }
        else if (RoundManager.RoundInstance._roundLeft <= 5 && PlayerHealthRound - PlayerActualHealth < 100)
        {
            RoundManager.RoundInstance.player1Streak = 0;
            RoundManager.RoundInstance.player2Streak++;
            Player2Wins();
        }
    }

    private void Player1Wins()
    {
        if (RoundManager.RoundInstance.player1Streak > 1)
        {
            Debug.Log("gana jugador uno");
            Player1Score++;
            AddScorePlayer1(525);
            AddScorePlayer2(450);
        }
        else
        {
            Debug.Log("gana jugador uno");
            Player1Score++;
            AddScorePlayer1(450);
            AddScorePlayer2(350);
        }
    }

    private void Player2Wins()
    {
        if (RoundManager.RoundInstance.player2Streak > 1)
        {
            Debug.Log("gana jugador dos");
            Player2Score++;
            AddScorePlayer2(525);
            AddScorePlayer1(450);
        }
        else
        {
            Player2Score++;
            Debug.Log("gana jugador dos");
            AddScorePlayer2(450);
            AddScorePlayer1(350);
        }
    }
    public void GoldReset()
    {
        Player1Gold = 550;
        Player2Gold = 550;
    }

    public void Victory()
    {
        _panel.SetActive(true);
    }
}