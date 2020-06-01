using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{

    public Transform enemyAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;


    public float attack = 1.0f;
    public float maxHealth = 20.0f;
    public float currentHealth;

    public float attackRate = 2f;
    float nextAttackTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //if (GetComponent<PlayerMovementBehavior>().)
            //{
            //    //NOTICE: ATTACK DOES DOUBLE DAMAGE! NEEDS TO BE FIXED
            //    Attack();
            //    nextAttackTime = Time.time + 1f / attackRate;
            //}
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovementBehavior>().enabled = false;
        this.enabled = false;
    }


    void Attack()
    {
        //Detect enemies in range of attack
        Collider[] hitPlayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, playerLayer);

        //Damage enemies
        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Attacked player");
            player.GetComponent<EnemyAttackBehavior>().TakeDamage(attack);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, attackRange);
    }

    
}
