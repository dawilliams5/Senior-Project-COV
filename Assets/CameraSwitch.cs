using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public int manager = 0;
    public BoxCollider2D wall;
    public bool switched = false;
    public OpenDoor OpenDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.layer == 7)
        {
            if (!switched)
            {
                if (Camera1.active)
                {
                Camera1.SetActive(false);
                Camera2.SetActive(true);
                manager = 1;
                wall.isTrigger = false;
                switched = true;
            }
                else
            {
                Camera1.SetActive(true);
                Camera2.SetActive(false);
                manager = 0;
                wall.isTrigger = false;
                switched = true;
            }
                OpenDoor.Reset();
            }
            
        }
        
    } 
}
