using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindow : MonoBehaviour
{
    public Conveyor conveyor;
    public GameManager gameManager;
    public Transform coin;

    public TMPro.TextMeshPro conveyorLevelText, costText, buyText;

    public static readonly Dictionary<int, int> costPairs = new Dictionary<int, int>
    {
        {1, 250 },
        {2, 500 },
        {3, 1000 },
        {4, 2000 },
        {5, 9999 },
    };

    public void UpdateInfo()
    {
        conveyorLevelText.text = ("LVL " + conveyor.conveyorLevel.ToString());
        if (costPairs[conveyor.conveyorLevel] == 9999)
        {
            costText.text = ("Макс. уровень");
            coin.gameObject.SetActive(false);
        }
        else
        {
            costText.text = costPairs[conveyor.conveyorLevel].ToString();
            coin.gameObject.SetActive(true);
        }
    }


}
