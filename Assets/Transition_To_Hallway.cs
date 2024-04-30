using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_To_Hallway : MonoBehaviour
{
    public GameObject Hallway;
    public Player player;
    public GameObject currentCamera;
    public GameObject hallwayCamera;
    public NewRoomDoor openDoor;
    public NewRoomDoor secondDoor;
    public New_Room_Spawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            player.transform.position = Hallway.transform.position;
            currentCamera.SetActive(false);
            hallwayCamera.SetActive(true);
            openDoor.Reset();
            secondDoor.Reset();
            spawn.Reset();
        }
    }
}

