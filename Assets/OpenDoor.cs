using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public EnemySpawner spawnNumber;
    public GameObject doorBlockage;
    private int ran = 0;
    private int spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = spawnNumber.spawnCount;
    }
    public void Door()
    {
        animator.SetTrigger("Close");
        new WaitForSeconds(200);
        
        doorBlockage.SetActive(false);
        //GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Reset()
    {
        animator.SetTrigger("Reset");

        doorBlockage.SetActive(true);
        //GetComponent<BoxCollider2D>().enabled=true;
    }
    // Update is called once per frame

    void Update()
    {
        if(spawned == player.killCount)
        {
            if (ran == 0)
            {
                ran++;
                Door();
            }
        }
    }
}
