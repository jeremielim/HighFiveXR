using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _score = 0;
        _scoreText.text = "" + _score;
    }
}