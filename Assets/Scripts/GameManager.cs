using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ConveyorItem hat, head, body;
    public Monster monsterToSpawn;
    public Conveyor[] conveyors;
    public Transform spawn;
    private int count;
    public ItemCreator[] creators;
    public static Action onItemsUsed;

    public int moneyCount;

    public void Start()
    {
        Conveyor.onToCraft += CheckForCraft;
        ConveyorItem.onSendIntoMachine += PrepareForCraft;
        ConveyorItem.onItemClick += UpdateMoney;
        ConveyorItem.onItemStopMoving += CreateAllItems;
        CreateAllItems();

        StartCoroutine(MoveItemsCooldown());
    }

    public void CreateAllItems()
    {
        for (int i = 0; i < creators.Length; i++)
        {
            creators[i].CreateItem();
        }
        StartCoroutine(MoveItemsCooldown());
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
        if (conveyors[0].conveyorItems[2] !=null && conveyors[1].conveyorItems[2] != null && conveyors[2].conveyorItems[2] != null)
        {
            conveyors[0].conveyorItems[2].canMove = true;
            conveyors[1].conveyorItems[2].canMove = true;
            conveyors[2].conveyorItems[2].canMove = true;
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
            onItemsUsed.Invoke();
        }
    }

    public IEnumerator MoveItemsCooldown()
    {
        yield return new WaitForSecondsRealtime(10f);
        StartConveyors();
    }

    public void StartConveyors()
    {
        for (int i = 0; i < conveyors.Length; i++)
        {
            conveyors[i].MoveItems();
        }
        MoveItemsCooldown();
    }
}
