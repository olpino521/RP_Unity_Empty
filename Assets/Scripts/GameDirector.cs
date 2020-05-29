using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _loseText;

    private int _score = 0;
    private int _lifePoints = 3;

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void IncreaseScore(int points)
    {
        _score += points;
        _scoreText.text = _score.ToString();
    }

    public void DecreaseScore()
    {
        _lifePoints--;

        if(_lifePoints <= 0)
        {
            Destroy(_player);
            _loseText.SetActive(true);
        }
    }
}
