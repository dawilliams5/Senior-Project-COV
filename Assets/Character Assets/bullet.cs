using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;
    public int bounces = 1;
    public Rigidbody2D rb;
    public float damage = 10;
    public GameObject impact;
    private Vector2 direction;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
       
            rb.velocity = transform.right * speed;
        
        
    }
    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.velocity * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //for enemy damage https://youtu.be/wkKsl1Mfp5M?t=656
        //double check bullet collision is working
        MeleeEnemy enemy =  hitInfo.GetComponent<MeleeEnemy>();
        villianControls boss = hitInfo.GetComponent<villianControls>();
        Enemy_shoot mob = hitInfo.GetComponent<Enemy_shoot>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(boss  != null)
        {
            boss.TakeDamage(damage);
        }
        if (mob != null)
        {
            mob.TakeDamage(damage);
        }
       

        Instantiate(impact,transform.position, transform.rotation);
        Destroy(gameObject);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        bounces--;
        if(bounces <= 0)
        {
            Destroy(gameObject);
            return;
        }
        var firstContact = collision.contacts[0];
        Vector2 newVelocity = Vector2.Reflect(direction.normalized, firstContact.normal);
        Shoot(newVelocity.normalized);
        
        
    }
    public void UpgradeDamage(float Updamage)
    {
        damage += Updamage;
    }
    public void UpgradeSpeed(float Upspeed)
    {
        speed += Upspeed;
    }

}
