using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] float durationOfPowerUp = 3f;
    [SerializeField] float lifetimeOfPowerUp = 3f;

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }
    // Start is called before the first frame update
    public virtual void CollisionEffect(GameObject collidedWith)
    {
        StartCoroutine(PowerEffect(collidedWith));
    }

    public abstract void StartEffect(GameObject playerObject);

    public abstract void EndEffect(GameObject playerObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollisionEffect(collision.gameObject);
        }
    }

    IEnumerator PowerEffect(GameObject player)
    {
        StopCoroutine(DestroyAfterLifetime());
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        StartEffect(player);
        yield return new WaitForSeconds(durationOfPowerUp);
        EndEffect(player);
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetimeOfPowerUp);
        Destroy(gameObject);
    }
}
