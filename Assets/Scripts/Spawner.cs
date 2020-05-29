using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn = null;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private float spawnIntervals = 1f;

    float lastUpdate;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnIntervals >= lastUpdate)
        {
            float randomRange = Random.Range(-spawnRange/2, spawnRange/2);
            Instantiate(objectToSpawn, transform.position + (Vector3.right *randomRange),Quaternion.identity);
            lastUpdate = Time.time;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector2(spawnRange, 1));
    }
}
