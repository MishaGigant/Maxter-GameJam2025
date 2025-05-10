using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isWorking;
    public float spawnRate;
    public int enemyLevel;

    public Transform spawnPos;

    public Monster monsterPrefab;

    [SerializeField] private ConveyorItem[] hatPrefabs;
    [SerializeField] private ConveyorItem[] headPrefabs;
    [SerializeField] private ConveyorItem[] bodyPrefabs;


    public int currentWave = -1;
    public int currentWavePart = 0;
    public int currentEnemyNum = 0;
    public WaveEnemyType currentWaveEnemyType;

    [SerializeField]private int amountOfEnemyToSpawn; //в текущей WavePart
    [SerializeField] private int amountOfWavePart; //в текущей волне

    public Wave[] waves;

    public WaveInfoTabel waveInfoTabel;

    private void Start()
    {
        StartNewWave();
        StartCoroutine(SpawnTimer());
    }
    IEnumerator SpawnTimer()
    {
        if (isWorking)
        {
            currentEnemyNum++;
            waveInfoTabel.UpdateInfo(currentWavePart, amountOfEnemyToSpawn - currentEnemyNum);
            if (currentEnemyNum <= amountOfEnemyToSpawn)
            {
                if (currentWaveEnemyType == WaveEnemyType.Random)
                    SpawnRandom();
                else if (currentWaveEnemyType == WaveEnemyType.Selected)
                    SpawnSelected(waves[currentWave].monsterInfos[currentWavePart].hatPrefab,
                                  waves[currentWave].monsterInfos[currentWavePart].headPrefab,
                                  waves[currentWave].monsterInfos[currentWavePart].bodyPrefab);
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                if (currentWavePart < amountOfWavePart)
                {
                    StartNewWavePart();
                }
                else
                {
                    StartNewWave();
                }
            }
            StartCoroutine(SpawnTimer());
        }

    }
    public void StartNewWave()
    {
        currentWave++;
        if (currentWave == waves.Length)
        {
            isWorking = false;
            return;
        }
        currentWavePart = 0;
        currentEnemyNum = 0;
        amountOfWavePart = waves[currentWave].amoutOfEnemyForEachType.Length-1;
        amountOfEnemyToSpawn = waves[currentWave].amoutOfEnemyForEachType[currentWavePart];
        currentWaveEnemyType = waves[currentWave].waveEnemySpawnType[0];

        waveInfoTabel.SetNewEnemyIcons(waves[currentWave], currentWave);
    }
    public void StartNewWavePart()
    {
        currentWavePart++;
        currentEnemyNum = 0;
        amountOfEnemyToSpawn = waves[currentWave].amoutOfEnemyForEachType[currentWavePart];
        currentWaveEnemyType = waves[currentWave].waveEnemySpawnType[currentWavePart];
    }
    private void SpawnSelected(ConveyorItem hat, ConveyorItem head, ConveyorItem body)
    {
        Monster m = Instantiate(monsterPrefab, spawnPos.position, Quaternion.identity);
        m.team = Monster.Team.Enemy;

        hat.itemStats.GetStats(hat);
        head.itemStats.GetStats(head);
        body.itemStats.GetStats(body);

        m.MakeMonster(hat, head, body);
    }
    private void SpawnRandom()
    {
        Monster m = Instantiate(monsterPrefab, spawnPos.position, Quaternion.identity);
        m.team = Monster.Team.Enemy;

        ConveyorItem hat = hatPrefabs[Random.Range(0, hatPrefabs.Length)].GetComponent<ConveyorItem>();
        ConveyorItem head = headPrefabs[Random.Range(0, headPrefabs.Length)].GetComponent<ConveyorItem>();
        ConveyorItem body = bodyPrefabs[Random.Range(0, bodyPrefabs.Length)].GetComponent<ConveyorItem>();
        hat.itemStats.GetStats(hat);
        head.itemStats.GetStats(head);
        body.itemStats.GetStats(body);

        m.MakeMonster(hat, head, body);
       
    }
}
