using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex = 0;
    public GameObject tutorialScreen;
    public GameObject exciteText;
    public float waitTime = 3f;
    public EnemySpawner spawner;
    private void Start()
    {
        exciteText.SetActive(false);
        tutorialScreen.SetActive(true);
    }
    private void Update()
    {

        if (popUpIndex >= 0 && popUpIndex < popUps.Length)
        {
            for (int i = 0; i <= popUps.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popUps[popUpIndex].SetActive(true);
                }
                else
                {
                    popUps[popUpIndex].SetActive(false);
                }
            }
            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    popUpIndex++;
                }

            }
            else if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 3)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 4)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    popUpIndex++;
                    spawner.FirstSpawn();
                }
            }
            else
            {
                exciteText.SetActive(true);
                if (waitTime <= 0)
                {
                    tutorialScreen.SetActive(false);
                    //set spawner to active
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}