using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public WaveEnemyType[] waveEnemySpawnType;

    public int[] amoutOfEnemyForEachType;

    public MonsterInfo[] monsterInfos;
}

[System.Serializable]
public class MonsterInfo
{
    public bool isRandom;
    public ConveyorItem hatPrefab;
    public ConveyorItem headPrefab;
    public ConveyorItem bodyPrefab;

    public void GetAllStats()
    {
        hatPrefab.itemStats.GetStats(hatPrefab);
        headPrefab.itemStats.GetStats(headPrefab);
        bodyPrefab.itemStats.GetStats(bodyPrefab);
    }
}
public enum WaveEnemyType
{
    Random,
    Selected
}
