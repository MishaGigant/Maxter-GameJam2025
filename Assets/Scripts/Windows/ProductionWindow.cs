using UnityEngine;

public class ProductionWindow : MonoBehaviour
{
    public int[] cost;
    public string[] skinName;
    public bool[] isBought;
    public int equipedSkin;
    public TMPro.TextMeshPro nameText, costText, equipText;
    public Transform costParent, equipParent;
    public SpriteRenderer windowSprite;
    public int skinID;
    public AudioManager src;

    public void Start()
    {

        UpdatePage();
    }
    public void UpdatePage()
    {
        nameText.text = skinName[skinID];
        if (isBought[skinID])
        {
            costParent.gameObject.SetActive(false);
            equipParent.gameObject.SetActive(true);
            if (equipedSkin == skinID)
            {
                windowSprite.sprite = Resources.LoadAll<Sprite>("Mirror window bought")[0];
                equipText.text = "Equiped";
            }
            else
            {
                windowSprite.sprite = Resources.LoadAll<Sprite>("Mirror window")[0];
                equipText.text = "Equip";
            }
        }
        else
        {
            windowSprite.sprite = Resources.LoadAll<Sprite>("Mirror window")[0];
            costParent.gameObject.SetActive(true);
            equipParent.gameObject.SetActive(false);
            costText.text = cost[skinID].ToString();
        }

    }

    public void NextSkin()
    {
        if (skinID == skinName.Length - 1)
        {
            skinID = 0;
        }
        else
        {
            skinID++;
        }
        src.Play(skinName[skinID]);
        UpdatePage();
    }

    public void PrevSkin()
    {
        if (skinID == 0)
        {
            skinID = skinName.Length - 1;
        }
        else
        {
            skinID--;
        }
        src.Play(skinName[skinID]);
        UpdatePage();
    }

    public void BuySkin()
    {
        //if (!isBought[skinID] && moneyCount.moneyCount >= cost[skinID])
        //{
            //moneyCount.moneyCount -= cost[skinID];
            src.Play("Upgrade bought");
            isBought[skinID] = true;
            UpdatePage();
        //}
        //else if (isBought[skinID] && skinID != equipedSkin)
        {
            equipedSkin = skinID;
            UpdatePage();
            //momo.anim.runtimeAnimatorController = momoSkinController[equipedSkin] as RuntimeAnimatorController;
        }
    }

    public void LoadSkin()
    {
        //momo.anim.runtimeAnimatorController = momoSkinController[equipedSkin] as RuntimeAnimatorController;
    }
}
