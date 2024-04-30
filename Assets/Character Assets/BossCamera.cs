using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public int manager = 0;
    public BoxCollider2D wall;
    public Boss_SPawner spawner;
    public bool switched = false;

    [SerializeField]
    public GameObject boss;

    

    public GameObject bossSpawnPoint;
    public GameObject spawnEffect;
    public NPC npc;
    private int test = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Passable(bool pass)
    {
        wall.isTrigger = pass;
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.layer == 7)
        {
                Passable(false);
                if (Camera1.active)
                {
                    Camera1.SetActive(false);
                    Camera2.SetActive(true);
                    manager = 1;
                    
                    switched = true;
                }
                else
                {
                    Camera1.SetActive(true);
                    Camera2.SetActive(false);
                    manager = 0;
                    
                    switched = true;
                }
            spawner.spawnBoss();
                //Instantiate(spawnEffect, bossSpawnPoint.transform.position, Quaternion.identity);
                //GameObject newEnemy = Instantiate(boss, bossSpawnPoint.gameObject.transform.position, Quaternion.identity);
            }

    }
}
