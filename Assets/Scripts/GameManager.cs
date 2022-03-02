using System;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _startButton;

    private int _highScore;
    private int _score;
    private int _livesLeft;
    private int _lifeStart;
    private bool _isAlive;
    private SpawnManager _spawnManagerComponent;

    private void Awake()
    {
        LoadHighScore();
    }

    private void Start()
    {
        _highScoreText.text = "High score: " + _highScore;
        _spawnManagerComponent = _spawnManager.GetComponent<SpawnManager>();
        _lifeStart = 3;
        _livesLeft = _lifeStart;
        _score = 0;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;
        _lifeText.text = "Life: " + _livesLeft;

        if (_livesLeft >= 1) return;
        StopGame();
    }

    public void StartGame()
    {
        _spawnManagerComponent.Invoke("SpawnTarget", 0.3f);

        _highScoreText.gameObject.SetActive(true);
        _scoreText.gameObject.SetActive(true);
        _lifeText.gameObject.SetActive(true);
        _isAlive = true;

        _livesLeft = _lifeStart;
        _score = 0;
        _startButton.SetActive(false);

        Debug.Log("Game start");
    }

    public bool IsAlive()
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

    private void StopGame()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            _highScoreText.text = "High score: " + _highScore;
            SaveHighScore();
        }

        _startButton.SetActive(true);
        _isAlive = false;
    }


    [System.Serializable]
    class SaveData
    {
        public int topScore;
    }

    public void SaveHighScore()
    {
        var data = new SaveData();
        data.topScore = _highScore;

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);

            _highScore = data.topScore;
        }
        else
        {
            _highScore = 0;
        }
    }
}