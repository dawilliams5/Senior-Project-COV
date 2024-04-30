using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class New_Room_Spawn : MonoBehaviour
{
    public Player player;
    public GameObject playerSpawnPoint;
    public GameObject[] enemySpawnPoints;
    public bool startSpawning;
    public GameObject[] enemyTypes;
    public bool enemySpawn;
    public bool enemyLeave;
    public bool once;
    public BoxCollider2D transition;
    public NewRoomDoor openDoor;
    public int spawnCount;
    public GameObject spawnEffect;
    public int startCount;
    public float spawnInterval;
    public int currentKillCount;
    public int countingKills;
    private int index;
    private int index2;
    // Start is called before the first frame update
    void Start()
    {
        startCount = spawnCount;
        countingKills = spawnCount;

    }
    public void Reset()
    {
        spawnCount = startCount + 1;
        startCount = spawnCount;
        startSpawning = false;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(player.transform.position,playerSpawnPoint.transform.position) < 1)
        {
            startSpawning = true;
            

        }
        if (startSpawning)
        {
            index = UnityEngine.Random.Range(0, enemyTypes.Length);
            if (!once)
            {
                StartCoroutine(spawnEnemy(spawnInterval, enemyTypes[index]));
                spawnCount--;
                once = true;
                currentKillCount = player.killCount;
            }
        }
        if(currentKillCount+startCount == player.killCount)
        {
            openDoor.Door();
            countingKills += spawnCount+1;
        }

    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if (spawnCount > 0)
        {
            index = UnityEngine.Random.Range(0, enemyTypes.Length);
            index2 = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
            yield return new WaitForSeconds(interval);
            Instantiate(spawnEffect, enemySpawnPoints[index2].transform.position, Quaternion.identity);
            GameObject newEnemy = Instantiate(enemy, enemySpawnPoints[index2].transform.position, Quaternion.identity);
            StartCoroutine(spawnEnemy(spawnInterval, enemyTypes[index]));
            spawnCount--;
        }

    }
}
