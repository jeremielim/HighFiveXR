using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isAlive;
    private int _score;
    private int _livesLeft;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private SpawnManager _spawnManager;


    private void Start()
    {
        _isAlive = true;
        _livesLeft = 3;
        _score = 0;
    }

    // life counter
    public void UpdateLife(int lifeAmount)
    {
        _livesLeft += lifeAmount;
    }

    public void UpdateScore(int scoreAmount)
    {
        _score += scoreAmount;
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

    public bool isAlive()
    {
        return _isAlive;
    }

    // Start game

    // Game over

    // top score
}