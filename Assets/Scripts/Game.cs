using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ChimneyGenerator _chimneyGenerator;
    [SerializeField] private GameScreen _startScreen;
    [SerializeField] private GameScreen _endScreen;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private RecordView _recordView;

    private void OnEnable()
    {
        _player.Died += OnPlayerDie;
        _startScreen.ButtonClicked += OnStartButtonClick;
        _endScreen.ButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDie;
        _startScreen.ButtonClicked -= OnStartButtonClick;
        _endScreen.ButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        _endScreen.Hide();
        _startScreen.Show();
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Hide();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Hide();
        _chimneyGenerator.ResetPool();
        StartGame();
    }

    private void OnPlayerDie()
    {
        Time.timeScale = 0;
        _recordView.Show();
        _endScreen.Show();
        _scoreView.SetAlpha(1);
    }

    private void StartGame()
    {
        _recordView.Hide();

        Time.timeScale = 1;
        _player.ResetPlayer();
        _scoreView.ResetAlpha();
    }
}
