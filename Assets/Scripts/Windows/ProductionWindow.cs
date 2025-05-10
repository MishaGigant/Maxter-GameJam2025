using UnityEngine;

public class ProductionWindow : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
    public int[] cost;
    public string[] itemName;
    public int itemID;
    public int equipedSkin;
    public TMPro.TextMeshPro nameText, costText;
    public SpriteRenderer windowSprite;
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
        if (itemID == itemName.Length - 1)
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
        if (itemID == 0)
        {
            itemID = itemName.Length - 1;
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
            gameManager.moneyCount -= cost[itemID];
            //src.Play("Upgrade bought");
            equipedSkin = itemID;
            UpdatePage();
        }
    }

>>>>>>> Stashed changes
}
