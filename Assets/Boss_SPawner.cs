using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_SPawner : MonoBehaviour
{
    [SerializeField]
    public GameObject boss;

    public GameObject exit;
    public BoxCollider2D enter;
    public int bossKillCount;
    public GameObject spawnEffect;
    public SwitchLevel bossSwitchLevel;
    public bool spawned = false;
    public Player player;
    public int needBossKills = 1;
    public bool firstSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        bossKillCount = player.bossKillCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossKillCount+1 == player.bossKillCount)
        {
            bossSwitchLevel.floorOpen();
            exit.GetComponent<BoxCollider2D>().enabled = true;
            bossKillCount++;
        }
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
            yield return new WaitForSeconds(interval);
            Instantiate(spawnEffect, transform.position, Quaternion.identity);
            GameObject newEnemy = Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);

    }
    
    public void spawnBoss()
    {
        spawned = true;
        /*if (firstSpawn)
        {
            Instantiate(spawnEffect, transform.position, Quaternion.identity);
            GameObject newEnemy = Instantiate(boss, this.gameObject.transform.position, Quaternion.identity);
            newEnemy.SetActive(false);
            firstSpawn = false;
        }
        */
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
        GameObject newEnemy1 = Instantiate(boss, this.gameObject.transform.position, Quaternion.identity);



        //Instantiate(spawnEffect, transform.position, Quaternion.identity);
        //Instantiate(boss, this.gameObject.transform.position, Quaternion.identity);
        //StartCoroutine(spawnEnemy(2, boss));
    }
}
