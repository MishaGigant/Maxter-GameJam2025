using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public Conveyor conveyor;
    public GameObject conveyorItem;
    public GameObject[] itemsToMake;
    public StatWindow statWindow;
    public ProductionWindow productionWindow;
    public void CreateItem()
    {
        if (conveyor.conveyorItems[0] != null)
        {
            return;
        }
        int i = productionWindow.equipedSkin;
        if( i == 0)
        {
            conveyorItem = Instantiate(itemsToMake[Random.Range(0, conveyor.conveyorLevel)], conveyor.itemSlots[0].position, Quaternion.identity, conveyor.transform);
        }
        else
        {
            conveyorItem = Instantiate(itemsToMake[i - 1], conveyor.itemSlots[0].position, Quaternion.identity, conveyor.transform);
        }
        ConveyorItem item = conveyorItem.GetComponent<ConveyorItem>();
        item.conveyor = conveyor;
        item.statWindow = statWindow;
        item.itemLevel = conveyor.conveyorLevel - 1;
        item.itemStats.GetStats(item);
        item.conveyor.conveyorItems[0] = item;
    }
}
