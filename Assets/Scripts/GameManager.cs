using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _startButton;

    private int _score;
    private int _livesLeft;
    private int _lifeStart;
    private bool _isAlive;
    private SpawnManager _spawnManagerComponent;

    private void Start()
    {
        _spawnManagerComponent = _spawnManager.GetComponent<SpawnManager>();
        _scoreText.gameObject.SetActive(false);
        _lifeText.gameObject.SetActive(false);
        _lifeStart = 3;
        _livesLeft = _lifeStart;
        _score = 0;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;
        _lifeText.text = "Life: " + _livesLeft;

        if (_livesLeft < 1)
        {
            GameOver();
            _isAlive = false;
        }
    }

    public void StartGame()
    {
        _spawnManagerComponent.Invoke("SpawnTarget", 0.3f);
        
        _scoreText.gameObject.SetActive(true);
        _lifeText.gameObject.SetActive(true);
        _isAlive = true;

        _livesLeft = _lifeStart;
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

    private void GameOver()
    {
        _startButton.SetActive(true);
        Debug.Log("Game over");
    }


    [System.Serializable]
    class SaveData
    {
        public Color topScore;
    }
}