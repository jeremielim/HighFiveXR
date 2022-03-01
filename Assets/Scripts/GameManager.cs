using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _startButton;
    

    private bool _isAlive;
    private bool _gameStart;

    private int _score;
    private int _livesLeft;

    private void Start()
    {
        _livesLeft = 3;
        _score = 0;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;
        _lifeText.text = "Life: " + _livesLeft;

        if (_livesLeft < 1)
        {
            _isAlive = false;
        }

        isAlive();
    }

    public void StartGame()
    {
        _startButton.SetActive(false);
        _isAlive = true;
        _spawnManager.enabled = true;
        _spawnManager._willSpawn = true;
    }

    public bool isAlive()
    {
        return _isAlive;
    }

    public void UpdateLife(int lifeAmount)
    {
        _livesLeft += lifeAmount;
    }

    public void UpdateScore(int scoreAmount)
    {
        _score += scoreAmount;
    }

    // Game over

    // top score
}