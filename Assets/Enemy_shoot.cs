using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot : MonoBehaviour
{
    public float speed = 3f;
    public float lineOfSite = 14f;
    public float shootingRange = 7f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float health = 100;
    public bool dead = false;
    private float distanceFromPlayer = 0f;
    private Player playerScript;
    public Player player1;
    public GameObject deathEffect;
    public Animator animator;
    public GameObject bullet;
    public GameObject bulletParent;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
            Debug.LogError("Expected 'player' (transform) to be initialized but found null!");

    }
    void FlipTowardsPlayer()
    {
        // Compare the position of the player and the lizard
        if (player.position.x < transform.position.x)
        {

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (player.position.x > transform.position.x)
        {

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || animator == null) return;
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        FlipTowardsPlayer();
        /*if (distanceFromPlayer == null)
            Debug.LogError("Expected 'distancefromplayer' to be initialized but found null!");
        
        if (lineOfSite == null)
            Debug.LogError("Expected 'lineofsite' to be initialized but found null!");
        if (shootingRange == null)
            Debug.LogError("Expected 'shootingrange' to be initialized but found null!");
        */
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            animator.SetBool("isShooting", false);
        }
        //if (nextFireTime == null)
          //  Debug.LogError("Expected 'nextFiretime' to be initialized but found null!");
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            animator.SetBool("isMoving", false);
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!dead)
            {
                die();
                player1.AddKillCount();
                dead = true;
            }

        }
    }
    void die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}


