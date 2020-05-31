using UnityEngine;

public class ScaleController : MonoBehaviour
{
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 5f;
    // Start is called before the first frame update
    void Start()
    {
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector2(randomScale, randomScale);
    }
}
