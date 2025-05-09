using UnityEngine;

public class StatInfo
{
    public ItemConstantStats conStat;
    public string text;

    public StatInfo(ItemConstantStats conStat, string text)
    {
        this.conStat = conStat;
        this.text = text;
    }
}
