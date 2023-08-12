using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static float spawnWait = 1.5f;
    float startWait = 0.5f;
    static float waveWait = 6.0f;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] spawnPoints;
    public static int enemyAmount;
    public static int enemyMaxAmount = 25;
    static int enemyMinAmount = enemyMaxAmount - 1;
    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(EnemyWaves());
        spawnWait = 1.5f;
        waveWait = 6.0f;
        enemyMaxAmount = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            if(enemyAmount <= enemyMinAmount){
            for(int i = 0; i < enemyMaxAmount; i++)
            {
                Vector2 enemySpawn = spawnPoints[Mathf.RoundToInt(Random.Range(0f, 9f))].transform.position;
                GameObject enemy = Instantiate(enemies[Mathf.RoundToInt(Random.Range(0f, 5f))], enemySpawn, Quaternion.identity);
                enemyAmount++;
                yield return new WaitForSeconds(spawnWait);
            }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public static void SubtractWaveWait()
    {
        waveWait -= waveWait/5;
        enemyMaxAmount += 1;
        enemyMinAmount = enemyMaxAmount - 2;
    }

    public static void SubtractSpawnWait()
    {
        spawnWait -= spawnWait/5;
        enemyMaxAmount += 1;
        enemyMinAmount = enemyMaxAmount - 2;
    }
}
