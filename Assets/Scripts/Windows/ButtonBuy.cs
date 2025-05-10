using UnityEngine;

public class ButtonBuy : MonoBehaviour
{
    public UpgradeWindow window;

    private void OnMouseDown()
    {
        if (window.conveyor.conveyorLevel < 5 && window.gameManager.moneyCount >= UpgradeWindow.costPairs[window.conveyor.conveyorLevel])
        {
            int i = UpgradeWindow.costPairs[window.conveyor.conveyorLevel];
            window.conveyor.conveyorLevel++;

            window.gameManager.UpdateMoney(-i);
            window.UpdateInfo();
        }
        else
        {
            return;
        }
        
    }
}
