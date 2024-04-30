using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoomDoor : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public New_Room_Spawn spawnNumber;
    public GameObject doorBlockage;
    private int ran = 0;
    private int spawned;
    private int currentKills;
    // Start is called before the first frame update
    void Start()
    {
        spawned = spawnNumber.spawnCount; 
    }
    public void Door()
    {
        animator.SetBool("Close", true);
        animator.SetBool("Reset", false);
        doorBlockage.SetActive(false);
        //GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Reset()
    {
        animator.SetBool("Close", false);
        animator.SetBool("Reset", true);
        doorBlockage.SetActive(true);
        //GetComponent<BoxCollider2D>().enabled=true;
    }
    // Update is called once per frame

    void Update()
    {
    }
}

