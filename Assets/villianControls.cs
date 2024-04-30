using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class villianControls : MonoBehaviour
{
    public float health = 100;
    public float movespeed = 2f;
    public Animator animator;
    public float attackDistance;
    public GameObject player;
    public Player user;
    public bool playerLeft;
    Vector2 moveDirection;
    public Animator door;
    public GameObject deathEffect;  
    public DetectionZone zone;
    public DetectionZone zoneLeft;
    public bool dead = false;
    public SwitchLevel switchLevel;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 10)
        {
            Die();
            user.bossKillCount += 1;
        }
    }
    void Die()
    {
        dead = true;
        switchLevel.bossDie();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //animator.SetBool("Is_Dead", true);

    }
    public bool _hasTarget = false;

    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool("hasTarget", value);
        }
    }
    public bool CanMove
    {
        get 
        { 
            return animator.GetBool("canMove"); 
        }
        
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    { /*
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSpirite();
        animator.SetFloat("speed", horizontalInput);
        if(animator.GetFloat("speed")== 0)
        {
            animator.SetFloat("Horizontal",0);
        }
        else
        {
            animator.SetFloat("Horizontal", 1);
        }
        */
        
        HasTarget = (zone.detectedColliders.Count > 0 || zoneLeft.detectedColliders.Count > 0);
        Vector3 playerPosition = player.gameObject.transform.position;

        if (this.gameObject.transform.position.x < playerPosition.x)
        {
            animator.SetBool("Face_Left", false);
            playerLeft = false;
        }
        else
        {
            animator.SetBool("Face_Left", true);
            playerLeft = true;
        }

        Vector3 direction = (playerPosition - transform.position).normalized;
        moveDirection = direction;
        if (CanMove)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movespeed;
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
        
    }
        /*
        Vector2 a = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 b = new Vector2(this.transform.position.x, this.transform.position.y);
        float distance = Vector2.Distance(a, b);
        if(distance < 3) 
        {
            int randomIndex = Random.Range(0, 2);
            if(randomIndex == 0) 
            {
                Attack1();
            }
            if(randomIndex == 1) 
            {
                Attack2();
            }
            else
            {
                Attack3();
            }
        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * movespeed, rb.velocity.y);
    }
    public void Attack1()
    {
        animator.SetBool("Attack1", true);
        if (playerLeft)
        {
            attack1Left.gameObject.SetActive(true);
        }
        else
        {
            attack1.gameObject.SetActive(true);
        }
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        new WaitForSeconds(2);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        attack1Left.gameObject.SetActive(false);
        attack1.gameObject.SetActive(false);
        animator.SetBool("Attack1", false);
    }
    public void Attack2()
    {
        animator.SetBool("Attack2", true);
        if (playerLeft)
        {
            attack2Left.gameObject.SetActive(true);
        }
        else
        {
            attack2.gameObject.SetActive(true);
        }
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        new WaitForSeconds(2);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        attack2Left.gameObject.SetActive(false);
        attack2.gameObject.SetActive(false);
        animator.SetBool("Attack2", false);
    }
    public void Attack3()
    {
        animator.SetBool("Attack3", true);
        if (playerLeft)
        {
            attack3Left.gameObject.SetActive(true);
        }
        else
        {
            attack3.gameObject.SetActive(true);
        }
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        new WaitForSeconds(2);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        attack3Left.gameObject.SetActive(false);
        attack3.gameObject.SetActive(false);
        animator.SetBool("Attack3", false);
    }

    void FlipSpirite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            player.killCount += 5;
        }
    }
        */

}

