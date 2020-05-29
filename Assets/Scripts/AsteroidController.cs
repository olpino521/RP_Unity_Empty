using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0,-speed * Time.deltaTime));
    }
}
