using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;

    int health;
    bool isDead;

    void Start()
    {
        health = maxHealth;
    }

    public void TookDamage(int damage)
    {
        if (isDead) return;
        health -= damage;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Died();
        }
    }

    void Died()
    {
        Destroy(gameObject);
    }
}
