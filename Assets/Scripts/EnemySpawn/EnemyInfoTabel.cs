using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnemyInfoTable : MonoBehaviour
{
    public Image[] imageType;

    public Sprite[] allTypeOfConstantStats; //0 - базовый, 1 - огненный, 2 - ледяной, 3 - спуки, 4 - святой
    private Dictionary<ItemConstantStats, Sprite> itemConstantStatsDict;

    private void Start()
    {
        itemConstantStatsDict = new Dictionary<ItemConstantStats, Sprite>
        {
            {ItemConstantStats.NormalDmg, allTypeOfConstantStats[0]},
            {ItemConstantStats.NormalWeak, allTypeOfConstantStats[0]},
            {ItemConstantStats.NormalRes, allTypeOfConstantStats[0]},
            {ItemConstantStats.FireDmg, allTypeOfConstantStats[1]},
            {ItemConstantStats.FireRes, allTypeOfConstantStats[1]},
            {ItemConstantStats.FireWeak, allTypeOfConstantStats[1]},
            {ItemConstantStats.ColdDmg, allTypeOfConstantStats[2]},
            {ItemConstantStats.ColdRes, allTypeOfConstantStats[2]},
            {ItemConstantStats.ColdWeak, allTypeOfConstantStats[2]},
            {ItemConstantStats.SpookyDmg, allTypeOfConstantStats[3]},
            {ItemConstantStats.SpookyRes, allTypeOfConstantStats[3]},
            {ItemConstantStats.SpookyWeak, allTypeOfConstantStats[3]},
            {ItemConstantStats.HolyDmg, allTypeOfConstantStats[4]},
            {ItemConstantStats.HolyRes, allTypeOfConstantStats[4]},
            {ItemConstantStats.HolyWeak, allTypeOfConstantStats[4]},

        };
    }
    public void SetMonsterInfo(MonsterInfo m)
    {
        imageType[0].sprite = itemConstantStatsDict[m.bodyPrefab.itemStats.constantStat];
        imageType[1].sprite = itemConstantStatsDict[m.headPrefab.itemStats.constantStat];
        imageType[2].sprite = itemConstantStatsDict[m.hatPrefab.itemStats.constantStat];
    }

}
