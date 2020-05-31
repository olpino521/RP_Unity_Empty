using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1f;
    [SerializeField] private int points = 1;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void ReceiveDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            GameDirector.Instance.IncreaseScore(points);
            Destroy(gameObject);
        }  
    }
}
