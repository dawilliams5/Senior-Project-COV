using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyType;

    public float spawnInterval = 3.5f;
    public GameObject spawnEffect;
    public int spawnCount;
    public TutorialManager tutorialManager;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnCount > 0 && tutorialManager.popUpIndex == 5)
        {
            StartCoroutine(spawnEnemy(spawnInterval, enemyType));
            spawnCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstSpawn()
    {
        if (spawnCount > 0)
        {
            StartCoroutine(spawnEnemy(spawnInterval, enemyType));
            spawnCount--;
        }
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(spawnCount > 0)
        {
        yield return new WaitForSeconds(interval);
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
        GameObject newEnemy = Instantiate(enemy,this.gameObject.transform.position,Quaternion.identity);
        StartCoroutine(spawnEnemy(spawnInterval, enemyType));
            spawnCount --;
        }
        
    }
}
