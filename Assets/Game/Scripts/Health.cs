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

	public GameObject destroyParticle;
	public GameObject transferParticle;

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
        if (!man) return;
        switch (enemyType)
        {
            case EnemyType.JumpEnemy:
                Spawner.numberOfJumps--;
                man.Jump();
                break;

            case EnemyType.DuckEnemy:
                Spawner.numberOfDucks--;
                man.Slide();
                break;
        }

		Instantiate(destroyParticle, transform.position+Vector3.up, Quaternion.identity);
		GameObject transfer = (GameObject)Instantiate(transferParticle, GameObject.Find("Man").transform.position, Quaternion.identity);
		transfer.transform.SetParent(GameObject.Find("Man").transform);

        GameOverStats.totalNumberDead++;
		Destroy(gameObject);
    }
}
