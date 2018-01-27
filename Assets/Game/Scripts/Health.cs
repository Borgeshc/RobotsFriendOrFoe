using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum EnemyType
    {
        JumpEnemy,
        DuckEnemy
    };

    public EnemyType enemyType;

    public int maxHealth;
    int health;
    bool isDead;


    AutoMove man;

    void Start()
    {
        health = maxHealth;
        man = GameObject.Find("Man").GetComponent<AutoMove>();
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
        switch (enemyType)
        {
            case EnemyType.JumpEnemy:
                Spawner.numberOfJumps--;
                man.Jump();
                break;

            case EnemyType.DuckEnemy:
                Spawner.numberOfDucks--;
                man.Duck();
                break;
        }

        Destroy(gameObject);
    }
}
