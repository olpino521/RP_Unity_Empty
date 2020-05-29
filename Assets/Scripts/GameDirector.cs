using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private GameObject _championText;

    [SerializeField]
    private GameObject[] _heart;

    [SerializeField]
    private GameObject _asteroidSpawner;

    [SerializeField]
    private GameObject _asteroidGroup;

    [SerializeField]
    private GameObject _bulletGroup;

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

        if(_score >= 20)
        {
            Destroy(_player);
            _championText.SetActive(true);
            _asteroidSpawner.SetActive(false);
            _asteroidGroup.SetActive(false);
            _bulletGroup.SetActive(false);

            Invoke("Restart", 1.5f);
        }
    }

    public void DecreaseLifePoint()
    {
        _lifePoints--;
        _heart[_lifePoints].SetActive(false);

        if(_lifePoints <= 0)
        {
            Destroy(_player);
            _loseText.SetActive(true);
            _asteroidSpawner.SetActive(false);
            _asteroidGroup.SetActive(false);
            _bulletGroup.SetActive(false);

            Invoke("Restart", 1.5f);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("AlexTest");
    }
}
