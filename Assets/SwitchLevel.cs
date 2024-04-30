using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class SwitchLevel : MonoBehaviour
{
    public bool playerClose = false;
    public bool bossDefeated = false;
    public GameObject player;
    public weapon weapon;
    public Animator animator;
    public GameObject currentCamera;
    public GameObject spawnPoint1;
    public GameObject camera1;
    public GameObject spawnPoint2;
    public GameObject camera2;
    public bool switched = false;
    public int index;
    public GameObject npcSpawnLocation;
    public NPC npc;
    public villianControls villian;

    public BoxCollider2D exit;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerClose && bossDefeated)
        {
            animator.SetBool("Reset", true);
            animator.SetBool("Boss_Defeated", false);
            currentCamera.SetActive(false);
            index = UnityEngine.Random.Range(0, 2);
            if (index == 0)
            {
                camera1.SetActive(true);
                player.transform.position = spawnPoint1.transform.position;
            }
            if (index == 1)
            {
                camera2.SetActive(true);
                camera1.SetActive(false);
                player.transform.position = spawnPoint2.transform.position;
            }
            if (weapon.bulletDamage > 10)
            {
                double newDamage = weapon.bulletDamage * 0.1;
                weapon.bulletDamage -= newDamage;
            }
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            npc.Reset();
            villian.health += villian.health;
        }
        
    }

    
    public void floorOpen()
    {
        animator.SetBool("Reset", false);
        animator.SetBool("Boss_Defeated", true);
    }
    public void bossDie()
    {
        bossDefeated = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
        }
    }
}
