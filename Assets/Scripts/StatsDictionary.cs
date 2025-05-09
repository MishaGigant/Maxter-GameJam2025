using UnityEngine;
using System.Collections.Generic;

public class StatsDictionary : MonoBehaviour
{
    public static readonly Dictionary<NormalStats, StatRange> randomStatGoodRange = new Dictionary<NormalStats, StatRange>
   {
       {
            NormalStats.Damage,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 3),
                new Vector2Int (5, 10),
                new Vector2Int (10, 15),
                new Vector2Int (20, 30),
                new Vector2Int (35, 50)
            })
        },
       {
            NormalStats.Health,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (6, 8),
                new Vector2Int (20, 30),
                new Vector2Int (30, 40),
                new Vector2Int (60, 80),
                new Vector2Int (100, 140)
            })
        },
       {
            NormalStats.Speed,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 2),
                new Vector2Int (2, 4),
                new Vector2Int (4, 7),
                new Vector2Int (7, 11),
                new Vector2Int (11, 16)
            })
        },
       {
            NormalStats.AttackSpeed,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 3),
                new Vector2Int (5, 10),
                new Vector2Int (10, 15),
                new Vector2Int (20, 30),
                new Vector2Int (35, 50)
            })
        },
       {
            NormalStats.CritChance,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 3),
                new Vector2Int (5, 10),
                new Vector2Int (10, 15),
                new Vector2Int (20, 30),
                new Vector2Int (35, 50)
            })
        },
       {
            NormalStats.CritDamage,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 3),
                new Vector2Int (5, 10),
                new Vector2Int (10, 15),
                new Vector2Int (20, 30),
                new Vector2Int (35, 50)
            })
        },
       
   };
    public static readonly Dictionary<NormalStats, StatRange> randomStatBadRange = new Dictionary<NormalStats, StatRange>
    {
        {
            NormalStats.Damage,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-1, -2),
                new Vector2Int (-3, -5),
                new Vector2Int (-5, -10),
                new Vector2Int (-10, -20),
                new Vector2Int (-20, -35)
            })
        },
        {
            NormalStats.Health,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-3, -6),
                new Vector2Int (-10, -20),
                new Vector2Int (-15, -20),
                new Vector2Int (-30, -40),
                new Vector2Int (-50, -70)
            })
        },
        {
            NormalStats.Speed,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-1, -2),
                new Vector2Int (-2, -3),
                new Vector2Int (-3, -5),
                new Vector2Int (-5, -8),
                new Vector2Int (-8, -12)
            })
        },
        {
            NormalStats.AttackSpeed,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-1, -3),
                new Vector2Int (-5, -10),
                new Vector2Int (-10, -15),
                new Vector2Int (-20, -30),
                new Vector2Int (-35, -50)
            })
        },
        {
            NormalStats.CritChance,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-1, -3),
                new Vector2Int (-5, -10),
                new Vector2Int (-10, -15),
                new Vector2Int (-20, -30),
                new Vector2Int (-35, -50)
            })
        },
        {
            NormalStats.CritDamage,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (-1, -3),
                new Vector2Int (-5, -10),
                new Vector2Int (-10, -15),
                new Vector2Int (-20, -30),
                new Vector2Int (-35, -50)
            })
        },

    };
    public static readonly Dictionary<itemClass, StatRange> normalStatPairRange = new Dictionary<itemClass, StatRange>
    {
        {
            itemClass.Body,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (5, 1),
                new Vector2Int (15, 2),
                new Vector2Int (25, 3),
                new Vector2Int (40, 4),
                new Vector2Int (60, 5)
            })
        },
        {
            itemClass.Head,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (20, 1),
                new Vector2Int (40, 2),
                new Vector2Int (60, 3),
                new Vector2Int (80, 4),
                new Vector2Int (100, 5)
            })
        },
        {
            itemClass.Hat,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (5, 100),
                new Vector2Int (10, 110),
                new Vector2Int (15, 125),
                new Vector2Int (20, 150),
                new Vector2Int (25, 200)
            })
        },
    };
    public static readonly Dictionary<itemClass, StatRange> normalStatPair = new Dictionary<itemClass, StatRange>
    {
        {
            itemClass.Body,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (1, 3)
            })
        },
        {
            itemClass.Head,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (0, 2)
            })
        },
        {
            itemClass.Hat,
            new StatRange(new Vector2Int[]
            {
                new Vector2Int (4, 5)
            })
        },
    };
    public static readonly Dictionary<NormalStats, string> normalStatText = new Dictionary<NormalStats, string>
    {
        {NormalStats.Health, "Здоровье: " },
        {NormalStats.Damage, "Урон: " },
        {NormalStats.Speed, "Скорость: " },
        {NormalStats.AttackSpeed, "СКР Атаки: " },
        {NormalStats.CritChance, "Крит Шанс: " },
        {NormalStats.CritDamage, "Крит Урон: " }
    };
    public static readonly Dictionary<string, StatInfo> constantStatPair = new Dictionary<string, StatInfo>
    {
        {"Лисёнок", new StatInfo(ItemConstantStats.NormalRes, "Сопротивление обычному урону") },
        {"Толстый", new StatInfo(ItemConstantStats.NormalRes, "Тип урона: обычный") },
        {"Цилиндр", new StatInfo(ItemConstantStats.NormalRes, "Уязвимость к обычному урону") },
        {"Габриель", new StatInfo(ItemConstantStats.NormalRes, "Сопротивление святому урону") },
        {"Правидный", new StatInfo(ItemConstantStats.NormalRes, "Тип урона: святой") },
        {"Нимб", new StatInfo(ItemConstantStats.NormalRes, "Уязвимость к святому урону") },
        {"Мишка", new StatInfo(ItemConstantStats.NormalRes, "Тип урона: страшный") },
        {"Фредди", new StatInfo(ItemConstantStats.NormalRes, "Сопротивление страшному урону") }
    };
    public static readonly Dictionary<int, Dictionary<NormalStats, StatRange>> randomStatAligment = new Dictionary<int, Dictionary<NormalStats, StatRange>>
    {
        {0, randomStatGoodRange },
        {1, randomStatBadRange },
    };
}
