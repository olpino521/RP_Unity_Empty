using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _timer;

    public GameObject _player;

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

    [SerializeField]
    private int _minutes;

    [SerializeField]
    private int _seconds;

    [SerializeField]
    private GameObject _boss;

    [SerializeField]
    private GameObject _slider1;

    [SerializeField]
    private GameObject _slider2;

    [SerializeField]
    private GameObject _sc;

    private int _score = 0;
    private int _lifePoints = 3;
    private int _min;
    private float _sec;

    private void Start()
    {
        if(Instance == null)
            Instance = this;

        _min = _minutes;
        _sec = (float) _seconds;
    }

    private void Update()
    {
        if(_timer.gameObject.activeInHierarchy)
        {
            if(_min <= 0 && _sec <= 0)
            {
                Death();
            }

            else
            {
                if(_sec <= 0)
                {
                    _min--;
                    _sec = 60f; 
                }

                else
                {
                    _sec -= Time.deltaTime;
                }
            }

            float _mil = (_sec - (int)_sec) * 60f;

            _timer.text = ((_min >= 10)? "" : "0") + _min.ToString() + ":" + (((int)_sec >= 10)? "" : "0") + ((int)_sec).ToString() + ":" + (((int)_mil >= 10)? "" : "0") + ((int)_mil).ToString();
        }
    }

    public void IncreaseScore(int points)
    {
        _score += points;
        _scoreText.text = _score.ToString();

        if(_score >= 20)
        {
            _scoreText.gameObject.SetActive(false);
            _boss.SetActive(true);
            _slider1.SetActive(true);
            _slider2.SetActive(true);
            _timer.gameObject.SetActive(false);
            _asteroidGroup.SetActive(false);
            _sc.SetActive(false);
            
            for(int i = _bulletGroup.transform.childCount - 1; i >= 0 ; i--)
            {
                Destroy(_bulletGroup.transform.GetChild(i).gameObject);
            }
        }
    }

    public void DecreaseLifePoint()
    {
        _lifePoints--;
        _heart[_lifePoints].SetActive(false);

        if(_lifePoints <= 0)
        {
            Death();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("AlexTest");
    }

    public void Death()
    {
        Destroy(_player);
        _loseText.SetActive(true);
        _asteroidSpawner.SetActive(false);
        _asteroidGroup.SetActive(false);
        _bulletGroup.SetActive(false);

        Invoke("Restart", 1.5f);
    }

    public void Win()
    {
        Destroy(_player);
        _championText.SetActive(true);
        _asteroidSpawner.SetActive(false);
        _asteroidGroup.SetActive(false);
        _bulletGroup.SetActive(false);

        Invoke("Restart", 1.5f);
    }
}
