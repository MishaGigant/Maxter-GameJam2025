using UnityEngine;

public class ProductionWindow : MonoBehaviour
{
    public int[] cost;
    public string[] itemName;
    public int allowedPages;
    public int itemID;
    public int equipedSkin;
    public TMPro.TextMeshPro nameText, costText;
    public SpriteRenderer windowSprite;
    public Sprite[] itemSprites;
    public SpriteRenderer itemRenderer;
    public Sprite[] sprites;
    public AudioManager src;
    public Conveyor conveyor;
    public GameManager gameManager;

    public void Start()
    {

        UpdatePage();
    }
    public void UpdatePage()
    {
        nameText.text = itemName[itemID];
        itemRenderer.sprite = itemSprites[itemID];
        if (itemID == equipedSkin)
        {
            costText.text = "Создание";
            windowSprite.sprite = sprites[1];
        }
        else
        {
            windowSprite.sprite = sprites[0];
            costText.text = cost[conveyor.conveyorLevel - 1].ToString();
        }

    }

    public void NextItem()
    {
        allowedPages = conveyor.conveyorLevel;
        if (itemID == allowedPages)
        {
            itemID = 0;
        }
        else
        {
            itemID++;
        }
        //src.Play(itemName[itemID]);
        UpdatePage();
    }

    public void PrevSkin()
    {
        allowedPages = conveyor.conveyorLevel;
        if (itemID == 0)
        {

            itemID = allowedPages;
        }
        else
        {
            itemID--;
        }
        //src.Play(itemName[itemID]);
        UpdatePage();
    }

    public void BuyItem()
    {
        if (equipedSkin != itemID && gameManager.moneyCount >= cost[conveyor.conveyorLevel - 1])
        {
            gameManager.moneyCount -= cost[conveyor.conveyorLevel - 1];
            //src.Play("Upgrade bought");
            equipedSkin = itemID;
            UpdatePage();
        }
    }

}
