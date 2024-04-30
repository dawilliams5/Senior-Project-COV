using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    public Player player;
    public float health;
    public string num;
    public Text display;

    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.health;
        if(health >= 80)
        {
            display.color = Color.blue;
        }
        else if (79 >= health && health >= 50)
        {
            display.color = Color.green;
        }
        else
        {
            display.color = Color.red;
        }
        display.text = "Health: " + health;

        
    }
}
