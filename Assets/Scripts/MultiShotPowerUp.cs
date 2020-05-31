using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotPowerUp : PowerUp
{
    public override void EndEffect(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>()._bullets = 1;
    }

    public override void StartEffect(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>()._bullets = 3;
    }
}
