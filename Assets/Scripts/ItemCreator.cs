using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public Conveyor conveyor;
    public GameObject conveyorItem;
    public GameObject[] itemsToMake;
    public StatWindow statWindow;
    public void CreateItem()
    {
        if (conveyor.conveyorItems[0] != null)
        {
            return;
        }
        conveyorItem = Instantiate(itemsToMake[Random.Range(0, conveyor.conveyorLevel)], conveyor.itemSlots[0].position, Quaternion.identity, conveyor.transform);
        ConveyorItem item = conveyorItem.GetComponent<ConveyorItem>();
        item.conveyor = conveyor;
        item.statWindow = statWindow;
        item.itemLevel = conveyor.conveyorLevel - 1;
        item.itemStats.GetStats(item);
        item.conveyor.conveyorItems[0] = item;
    }
}
