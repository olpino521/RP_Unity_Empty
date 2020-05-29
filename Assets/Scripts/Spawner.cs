using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn = null;
    [SerializeField] private Transform asteroidGroup;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private float spawnIntervals = 1f;

    float lastUpdate;
    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnIntervals >= lastUpdate)
        {
            float realRange = (spawnRange - objectToSpawn.transform.localScale.x) / 2;
            float randomRange = Random.Range(-realRange, realRange);
            Instantiate(objectToSpawn, transform.position + (Vector3.right * randomRange),Quaternion.identity, asteroidGroup);
            lastUpdate = Time.time;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector2(spawnRange, 1));
    }
}
