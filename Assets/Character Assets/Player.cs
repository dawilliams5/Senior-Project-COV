using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6;
    public Rigidbody2D Rb;
    private Vector2 moveDirection;
    public Animator animator;
    public bool face_left;
    public GameObject firePoint;
    public CharacterController controller;
    float moveX = 0f;
    public float health = 100;
    public float maxHealth = 100;
    public GameObject deathEffect;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private GameObject bulletInst;
    public int killCount = 0;
    public int bossKillCount = 0;
    public float damageDelay = 1.5f;
    public bool invulnerable;

    private bool isDead;

    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    private void FixedUpdate()
    {
        Move();

    }
    public void TakeDamage(float damage)
    {
        // If the player is already invulnerable, return immediately
        //if (invulnerable) return;
        if (health != null)
        {
            health -= damage;
            if (health <= 0 && !isDead)
            {
                isDead = true;
                gameManager.gameOver();
                Die();
            }
            // Set the invulnerable flag to true
            //invulnerable = true;
            animator.SetTrigger("DamageTaken");
        }
        // Start the damage delay Coroutine
        //StartCoroutine(DamageDelay());
       
    }
    private IEnumerator DamageDelay()
    {
        animator.SetTrigger("DamageTaken");
        // Wait for the specified amount of time
        yield return new WaitForSeconds(damageDelay);

        // Set the invulnerable flag to false
        invulnerable = false;
    }
    public void UpgradeSpeed(float speed)
    {
        moveSpeed += speed;
    }
    public void Heal(float healed)
    {
        if (maxHealth < (health + healed))
        {
            health = maxHealth;
        }
        else
        {
            health += healed;
        }
    }
    public void UpgradeHealth(float Uphealth)
    {
        health += Uphealth;
        maxHealth += Uphealth;
    }
    public void AddKillCount()
    {
        killCount += 1;
    }
    public void AddBossKill()
    {
        killCount += 1;
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void FlipShoot()
    {
        firePoint.transform.Rotate(0, 180, 0);
    }
    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        animator.SetBool("Shooting", false);

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Shooting", true);
        }
        


        if (moveX < 0 || moveY < 0)
        {
            animator.SetBool("Face_Left", true);
        }
        if (moveX > 0 || moveY > 0)
        {
            animator.SetBool("Face_Left", false);
        }

    }
    void Move()
    {
        Rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}


