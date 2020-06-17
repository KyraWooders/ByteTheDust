using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public float attack = 4.0f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //public float health = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                  //NOTICE: ATTACK DOES DOUBLE DAMAGE! NEEDS TO BE FIXED
                  Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        //Damage enemies
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Attacked enemy");
            enemy.GetComponent<EnemyAttackBehavior>().TakeDamage(attack);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
