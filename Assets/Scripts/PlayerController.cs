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
    private GameObject _bulletPrefab;

    private float _lastMouseX;

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

            transform.position = newPos;

            _lastMouseX = Input.mousePosition.x;
        }
    }

    private void ArrowControl()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, 0);
        newPos.x = Mathf.Clamp(newPos.x, -8, 8);
        transform.position = newPos;
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
    }
}
