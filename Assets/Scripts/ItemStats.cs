using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public string whiteStatOneText, whiteStatTwoText;
    public NormalStats firstStat, secondStat;
    public int firstStatValue, secondStatValue;
    public string constantStatText, randomStatText;
    public ItemConstantStats constantStat;
    public NormalStats randomStat;
    public int randomStatValue;

    public void GetStats(ConveyorItem item)
    {
        NormalStats(item);
        RandomStatCount(item);
        ConstantStat(item);
        
    }
    
    public void NormalStats(ConveyorItem item)
    {
        StatRange stat = StatsDictionary.normalStatPairRange[item.itemClass];
        firstStatValue = stat.statRange[item.itemLevel].x;
        secondStatValue = stat.statRange[item.itemLevel].y;
        firstStat = (NormalStats)StatsDictionary.normalStatPair[item.itemClass].statRange[0].x;
        secondStat = (NormalStats)StatsDictionary.normalStatPair[item.itemClass].statRange[0].y;
        whiteStatOneText = StatsDictionary.normalStatText[firstStat];
        whiteStatTwoText = StatsDictionary.normalStatText[secondStat];
    }
    public void RandomStatCount(ConveyorItem item)
    {
        int statToGet = Random.Range(0, 6);
        int dictionaryToCheck = Random.Range(0, 2);
        randomStat = (NormalStats)statToGet;
        StatRange rng = StatsDictionary.randomStatAligment[dictionaryToCheck][randomStat];
        randomStatValue = Random.Range(rng.statRange[item.itemLevel].x, rng.statRange[item.itemLevel].y + 1);
        Debug.Log("Random stat - " + randomStat + ", stat value - " + randomStatValue);
        randomStatText = StatsDictionary.normalStatText[randomStat];
    }
    public void ConstantStat(ConveyorItem item)
    {
        StatInfo info = StatsDictionary.constantStatPair[item.itemName];
        constantStat = info.conStat;
        constantStatText = info.text;

    }
}

public enum NormalStats
{
    Health,
    Damage,
    Speed,
    AttackSpeed,
    CritChance,
    CritDamage
}
public enum ItemConstantStats
{
    FireDmg,
    ColdDmg,
    NormalDmg,
    SpookyDmg,
    HolyDmg,
    FireRes,
    ColdRes,
    NormalRes,
    SpookyRes,
    HolyRes,
    FireWeak,
    ColdWeak,
    NormalWeak,
    SpookyWeak,
    HolyWeak
}
