using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float minYSpeed = 1f;
    [SerializeField] private float maxYSpeed = 3f;
    [SerializeField] private float maxXSpeed = 1f;
    private float ySpeed;
    private float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ySpeed = Random.Range(minYSpeed, maxYSpeed);
        xSpeed = Random.Range(-maxXSpeed, maxXSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(xSpeed * Time.deltaTime,-ySpeed * Time.deltaTime));
    }
}
