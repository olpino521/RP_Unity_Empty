using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
