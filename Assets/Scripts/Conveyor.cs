using System;
using Unity.VisualScripting;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Transform[] itemSlots;
    public float moveFrequency;
    public ConveyorItem[] conveyorItems;
    public static Action onMoveItems;
    public static Action onToCraft;
    public int conveyorLevel;

    public float movementDuration;
    public AnimationCurve curve;


    public void MoveItems()
    {
        for (int i = 2; i != -1; i--)
        {
            if (conveyorItems[i] != null)
            {
                if (i == 2)
                {
                    onToCraft.Invoke();
                }
                else
                {
                    if (conveyorItems[i + 1] == null || conveyorItems[i + 1].canMove == true)
                    {
                        conveyorItems[i].canMove = true;
                    }
                    else
                    {
                        conveyorItems[i].canMove = false;
                    }
                }
                
            }
            
        }
        onMoveItems.Invoke();
    }
    
}
