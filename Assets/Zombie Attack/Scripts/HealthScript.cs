using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public GameObject deathObj;
    public int maxHealth = 100;
    private int currentHealth;

    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth <= 0)
        {
            if(deathObj != null)
            {
                Instantiate(deathObj);
            }
            OnDeath?.Invoke();
        }
    }
}
