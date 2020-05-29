using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;

        Invoke("Autodestruction", 2f);
    }

    private void Autodestruction()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Asteroid"))
        {
            GameDirector.Instance.IncreaseScore(1);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
