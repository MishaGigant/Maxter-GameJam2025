using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EnemyIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MonsterInfo monsterInfo;
    public Image iconImage;

    public TextMeshProUGUI amountText;
    public RectTransform infoTableSpawnPos;

    public EnemyInfoTable enemyInfoTable;

    public void SetupEnemyIcon(Sprite iconSpr, int amount, MonsterInfo mInf)
    {
        iconImage.sprite = iconSpr;
        monsterInfo = mInf;
        enemyInfoTable = GameObject.FindGameObjectWithTag("EnemyInfoTabel").GetComponent<EnemyInfoTable>();
        UpdateAmount(amount);
    }

    public void UpdateAmount(int amount)
    {
        amountText.text = amount.ToString();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        enemyInfoTable.GetComponent<RectTransform>().position = infoTableSpawnPos.position;
        enemyInfoTable.SetMonsterInfo(monsterInfo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        enemyInfoTable.SetTabelView(false);
    }
}
