using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool _mouseControl = false;

    [SerializeField]
    private float _speed = 2f;

    [SerializeField]
    private float _limitX = 8f;

    [SerializeField]
    private GameObject _bulletPrefab;    

    [SerializeField]
    private Transform _bulletgroup;

    private float _lastMouseX;

    internal int _bullets = 1;

    void Start()
    {
        _lastMouseX = Input.mousePosition.x;
    }

    void Update()
    {
        if(_mouseControl) MouseControl(); else ArrowControl();
        if(Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    private void MouseControl()
    {
        if(Input.mousePosition.x != _lastMouseX)
        {
            Vector3 newPos = transform.position;
            int _mouseInput = (int)((Input.mousePosition.x - _lastMouseX) / Mathf.Abs(Input.mousePosition.x - _lastMouseX));
            newPos.x += _mouseInput * _speed * Time.deltaTime;
            newPos.x = Mathf.Clamp(newPos.x, -_limitX, _limitX);
            transform.position = newPos;

            _lastMouseX = Input.mousePosition.x;
        }
    }

    private void ArrowControl()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, 0);
        newPos.x = Mathf.Clamp(newPos.x, -_limitX, _limitX);
        transform.position = newPos;
    }

    private void Shoot()
    {
        if(_bullets != 2)
        {
            Instantiate(_bulletPrefab, transform.position + Vector3.up, Quaternion.identity, _bulletgroup);

            if(_bullets == 3)
            {
                Instantiate(_bulletPrefab, transform.position + Vector3.up + (Vector3.left * 0.5f), Quaternion.identity, _bulletgroup);
                Instantiate(_bulletPrefab, transform.position + Vector3.up + (Vector3.right * 0.5f), Quaternion.identity, _bulletgroup);
            }
        }

        else
        {
            Instantiate(_bulletPrefab, transform.position + Vector3.up + (Vector3.left * 0.25f), Quaternion.identity, _bulletgroup);
            Instantiate(_bulletPrefab, transform.position + Vector3.up + (Vector3.right * 0.25f), Quaternion.identity, _bulletgroup);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Asteroid") || other.gameObject.CompareTag("EnemyBullet"))
        {
            GameDirector.Instance.DecreaseLifePoint();
            Destroy(other.gameObject);
        }
    }
}
