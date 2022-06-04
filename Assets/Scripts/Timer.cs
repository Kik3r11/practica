using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    bool gameOver;
    public GameObject ButtonRetry;
    public GameObject TextWon;
    public GameObject TextLost;
    public GameObject TextPaused;
    bool isPaused;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    private void Start()
    {
        _timeLeft = time;
        _timerOn = true;
    }

    private void Update()
    {

        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                Lose();
            }
        }
    }
    void TogglePause()
    {
        SetPause(!isPaused);
    }
    void SetPause(bool pause)
    {
        PauseGame(pause);
        TextPaused.SetActive(pause);
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    void Win()
    {
        GameOver();
        TextWon.SetActive(true);
        ButtonRetry.SetActive(true);
    }

    void Lose()
    {
        GameOver();
        TextLost.SetActive(true);
        ButtonRetry.SetActive(true);
    }
    void GameOver()
    {
        gameOver = true;
        PauseGame(true);
    }
    void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0.0f : 1.0f;
        isPaused = pause;
    }
}
