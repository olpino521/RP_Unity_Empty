using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField] private GameObject shieldPrefab;
    private GameObject shieldInstance;
    public override void EndEffect(GameObject playerObject)
    {
        shieldInstance = Instantiate(shieldPrefab, playerObject.transform);
        shieldInstance.transform.localScale = playerObject.transform.localScale * 1.5f;
    }

    public override void StartEffect(GameObject playerObject)
    {
        Destroy(shieldInstance);
    }

}
