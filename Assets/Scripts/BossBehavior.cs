using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _bossBullet;

    [SerializeField]
    private Transform _bulletgroup;

    [SerializeField]
    private float _phase1Speed;

    [SerializeField]
    private int _phase1HP;

    [SerializeField]
    private float _phase1FireFreq;

    [SerializeField]
    private Slider _phase1Slider;

    [SerializeField]
    private float _phase2Speed;

    [SerializeField]
    private int _phase2HP;

    [SerializeField]
    private float _phase2FireFreq;

    [SerializeField]
    private Slider _phase2Slider;

    private int _phase = 1;
    private int _health;
    private float _fireFreq;

    private void Start()
    {
        _fireFreq = _phase1FireFreq;
    }

    void Update()
    {
        switch(_phase)
        {
            case 1:
                Vector2 newPos = transform.position;
                newPos.x = Mathf.Lerp(newPos.x, GameDirector.Instance._player.transform.position.x, _phase1Speed * Time.deltaTime);
                transform.position = newPos;

                if(_fireFreq <= 0)
                {
                    Fire();
                    _fireFreq = _phase1FireFreq;
                }

                else
                {
                    _fireFreq -= Time.deltaTime;
                }
                break;

            case 2:
                Vector2 newPos2 = transform.position;
                newPos2.x = Mathf.Lerp(newPos2.x, GameDirector.Instance._player.transform.position.x, _phase2Speed * Time.deltaTime);
                transform.position = newPos2;

                if(_fireFreq <= 0)
                {
                    Fire();
                    _fireFreq = _phase2FireFreq;
                }

                else
                {
                    _fireFreq -= Time.deltaTime;
                }
                break;
        }

    }

    private void Fire()
    {
        Instantiate(_bossBullet, transform.position + Vector3.down + (Vector3.left * 0.25f), Quaternion.identity, _bulletgroup);
        Instantiate(_bossBullet, transform.position + Vector3.down + (Vector3.right * 0.25f), Quaternion.identity, _bulletgroup);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            if(_phase == 1)
            {
                _phase1Slider.value--;

                if(_phase1Slider.value <= 0)
                {
                    _phase1Slider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    _phase++;
                }
            }

            else 
            {
                _phase2Slider.value--;

                if(_phase2Slider.value <= 0)
                {
                    _phase1Slider.gameObject.SetActive(false);
                    _phase2Slider.gameObject.SetActive(false);
                    GameDirector.Instance.Win();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
