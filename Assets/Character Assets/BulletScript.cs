using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private GameObject target;
    public float speed = 10;
    private Rigidbody2D bulletRB;
    public GameObject impact;
    public float damage = 5;
    private Vector2 moveDir;
    private Player player;
    private Player playerScript;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        if (bulletRB == null)
            Debug.LogError("Expected 'bulletRB' to be initialized but found null!");
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
            Debug.LogError("Expected 'target' to be initialized but found null!");
        moveDir = (target.transform.position - transform.position).normalized * speed;
        if (moveDir == null)
            Debug.LogError("Expected 'moveDir' to be initialized but found null!");
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 3);
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D hitInfo)
    {
        //for enemy damage https://youtu.be/wkKsl1Mfp5M?t=656
        //double check bullet collision is working
        //MeleeEnemy enemy = hitInfo.GetComponent<MeleeEnemy>();
        //villianControls boss = hitInfo.GetComponent<villianControls>();
        if (hitInfo == null)
            Debug.LogError("Expected 'hitInfo' to be initialized but found null!");
        Debug.Log(hitInfo.name);
        player = hitInfo.GetComponent<Player>();
        if (player == null)
            Debug.LogError("Expected 'player' to be initialized but found null!");
        if (hitInfo.gameObject.tag == "Player")
        {
            playerScript = hitInfo.gameObject.GetComponent<Player>();
            playerScript.TakeDamage(damage);
        }


        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //bounces--;
        //if (bounces <= 0)
        //{
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);
        return;
        //}
        //var firstContact = collision.contacts[0];
        //Vector2 newVelocity = Vector2.Reflect(direction.normalized, firstContact.normal);
        //Shoot(newVelocity.normalized);


    }
}