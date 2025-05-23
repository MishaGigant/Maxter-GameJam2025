using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ConveyorItem hat, head, body;
    public Monster monsterToSpawn;
    public Conveyor[] conveyors;
    public Transform spawn;
    private int count;

    public int moneyCount;

    public void Start()
    {
        Conveyor.onToCraft += CheckForCraft;
        ConveyorItem.onSendIntoMachine += PrepareForCraft;
        ConveyorItem.onItemClick += UpdateMoney;

    }

    public void UpdateMoney(int moneyToAdd)
    {
        moneyCount += moneyToAdd;
    }
    public void MakeMonster()
    {
        if (hat != null && head != null && body != null)
        {
            Monster monster = Instantiate(monsterToSpawn, spawn.position, Quaternion.identity);
            monster.MakeMonster(hat, head, body);
            monster.team = Monster.Team.Player;
            monster.Flip();
            hat = null;
            head = null;
            body = null;
            count = 0;
        }
        else
        {
            return;
        }
    }

    public void CheckForCraft()
    {
        if (conveyors[0].conveyorItems[3] !=null && conveyors[1].conveyorItems[3] != null && conveyors[2].conveyorItems[3] != null)
        {
            conveyors[0].conveyorItems[3].canMove = true;
            conveyors[1].conveyorItems[3].canMove = true;
            conveyors[2].conveyorItems[3].canMove = true;
        }
    }

    public void PrepareForCraft(ConveyorItem itemToStore)
    {
        if (itemToStore.itemClass == itemClass.Hat)
        {
            hat = itemToStore;
        }
        else if (itemToStore.itemClass == itemClass.Head)
        {
            head = itemToStore;
        }
        else
        {
            body = itemToStore;
        }
        count++;
        if (count == 3)
        {
            MakeMonster();
        }
    }
}
