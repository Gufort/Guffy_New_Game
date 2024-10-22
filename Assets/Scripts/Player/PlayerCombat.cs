using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attack_pointer;
    public int attack_damage = 40;
    public float attack_range = 0.5f;
    public LayerMask enemyLayers;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            Attack();
        }
    }
    void Attack(){
        animator.SetTrigger("Attack");

        Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(attack_pointer.position, attack_range, enemyLayers);

        foreach(Collider2D enemy in hit_enemies){
            Debug.Log("Attacking" + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(attack_damage);
        }
    }
    void OnDrawGizmosSelector(){
        if(attack_pointer == null) return;
        Gizmos.DrawWireSphere(attack_pointer.position, attack_range);  
    }
}
