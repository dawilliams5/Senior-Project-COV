using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeEnemy : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public float health = 100;
    public GameObject deathEffect;
    public float damage = 10;
    public float moveSpeed = 3;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    public bool dead = false;
    public float lastAttackTime;
    public float damageTimeout = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if (!dead)
            {
            Die();
            player.AddKillCount();
            dead = true;
            }
            
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        
        if (this.gameObject.transform.position.x < playerPosition.x)
        {
            animator.SetBool("Face_left", false);
        }
        else
        {
            animator.SetBool("Face_left", true);
        }
        
        Vector3 direction = (playerPosition - transform.position).normalized;
        moveDirection = direction;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) *moveSpeed;


    }
    private void FixedUpdate()
    {
        
    }
    
   


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - lastAttackTime < 2) return;

        // CompareTag is cheaper than .tag ==
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);

            // Remember that we recently attacked.
            lastAttackTime = Time.time;
        }
    }

    /*
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        
        //Debug.Log(collision.tag.ToString() == "Player");
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
        } 
    }
    */
   
}
