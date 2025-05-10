using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ConveyorItem : MonoBehaviour
{
    public itemClass itemClass;
    public string itemName;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Conveyor conveyor;
    public static Action<ConveyorItem> onSendIntoMachine;
    public int currentPosition;
    private float currentTime;
    public Sprite sprite;
    public Transform connector;
    public Collider2D cd;
    public StatWindow statWindow;
    public Transform rayCastPoint;
    public Animator animator;

    public static Action<int> onItemClick;
    public bool isDestroyed;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool isMoving;
    private float movementDuration;

    private AnimationCurve curve;

    public int itemLevel;
    public ItemStats itemStats;

    public bool canMove;
    public bool isCreated;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        currentPosition = 0;
        Conveyor.onMoveItems += StartMovement;
    }

    public void OnMouseEnter()
    {
        if (isCreated) return;
        statWindow.gameObject.SetActive(true);
        statWindow.itemName.text = itemName;
        statWindow.whiteStatOne.text = (StatsDictionary.normalStatText[itemStats.firstStat] + itemStats.firstStatValue);
        statWindow.whiteStatTwo.text = (StatsDictionary.normalStatText[itemStats.secondStat] + itemStats.secondStatValue);
        statWindow.constantStat.text = (StatsDictionary.constantStatPair[itemName].text);
        statWindow.randomStat.text = (StatsDictionary.normalStatText[itemStats.randomStat] + itemStats.randomStatValue);
        if (itemStats.randomStatValue < 0)
        {
            statWindow.randomStat.color = new Color32(255, 120, 120, 255);
        }
        else
        {
            statWindow.randomStat.color = new Color32(143, 255, 121, 255);
        }
    }

    public void OnMouseOver()
    {
        if (isCreated) return;
        if (isDestroyed) {  return; }
        statWindow.gameObject.SetActive(true);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        statWindow.transform.position = new Vector3(worldPosition.x, worldPosition.y, -5);
    }

    public void OnMouseExit()
    {
        if (isCreated) return;
        statWindow.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (isCreated) return;
        statWindow.gameObject.SetActive(false);
        isDestroyed = true;
        int i = itemLevel * 25;
        onItemClick.Invoke(i);
        Conveyor.onMoveItems -= StartMovement;
        conveyor.conveyorItems[currentPosition] = null;
        Destroy(gameObject);
        
    }

    public void StartMovement()
    {
        if (canMove == false)
        {
            return;
        }
        startPosition = conveyor.itemSlots[currentPosition].position;
        endPosition = conveyor.itemSlots[currentPosition + 1].position;
        currentTime = 0;
        movementDuration = conveyor.movementDuration;
        curve = conveyor.curve;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving) return;

        currentTime += Time.deltaTime;

        float normalizedTime = Mathf.Clamp01(currentTime / movementDuration);

        float curveValue = curve.Evaluate(normalizedTime);
        transform.position = Vector3.Lerp(startPosition, endPosition, curveValue);

        if (currentTime >= movementDuration)
        {
            isMoving = false;
            transform.position = endPosition;
            conveyor.conveyorItems[currentPosition] = null;
            currentPosition += 1;
            conveyor.conveyorItems[currentPosition] = this;
            canMove = false;
            if (currentPosition == 3)
            {
                Conveyor.onMoveItems -= StartMovement;
                onSendIntoMachine.Invoke(this);
                conveyor.conveyorItems[currentPosition] = null;
                Destroy(gameObject);

            }
        }
    }
}

    public enum itemClass
{
    None,
    Hat,
    Head,
    Body
}
