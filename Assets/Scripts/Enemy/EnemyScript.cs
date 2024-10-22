using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public int max_hp = 100;
    int curr_hp;
    void Start()
    {
        curr_hp = max_hp;
    }

    public void TakeDamage(int damage){
        curr_hp -= damage;
        animator.SetTrigger("Hurt");
        if(curr_hp < 0){
            Die();
        }
    }
    
    void Die(){
        Debug.Log("Enemu died!!");
        animator.SetBool("IsDead", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
