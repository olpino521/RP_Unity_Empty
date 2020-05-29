using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    private int _score = 0;

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void IncreaseScore(int points)
    {
        _score += points;
    }
}
