using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
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
        Instance = this;
        DontDestroyOnLoad(gameObject);
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

        if (IsAlive()) return;

        _spawnManagerComponent.CancelInvoke();
        _spawnManagerComponent.DestroySpawnedTargets();
        StopGame();
    }

    public void StartGame()
    {
        _startButton.SetActive(false);

        _highScoreText.gameObject.SetActive(true);
        _scoreText.gameObject.SetActive(true);
        _lifeText.gameObject.SetActive(true);

        _spawnManagerComponent.SpawnTarget();

        _livesLeft = _lifeStart;
        _score = 0;

        Debug.Log("Game start");
    }

    private void StopGame()
    {
        _startButton.SetActive(true);
        _isAlive = false;

        if (_score <= _highScore) return;

        _highScore = _score;
        _highScoreText.text = "High score: " + _highScore;
        SaveHighScore();
    }

    private bool IsAlive()
    {
        return _isAlive = _livesLeft > 0 ? true : false;
    }

    public void UpdateLife(int lifeAmount)
    {
        _livesLeft += lifeAmount;
    }

    public void UpdateScore(int scoreAmount)
    {
        _score += scoreAmount;
    }


    [System.Serializable]
    private class SaveData
    {
        public int topScore;
    }

    private void SaveHighScore()
    {
        var data = new SaveData();
        data.topScore = _highScore;

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadHighScore()
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