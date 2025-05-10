using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class WaveInfoTabel : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public List<EnemyIcon> icons;

    public GameObject enemyIconPrefab;
    public RectTransform layout;
    public Sprite random;
    public void SetNewEnemyIcons(Wave wave, int currentWave)
    {
        waveText.text = "Волна №" + (currentWave + 1);
        icons.Clear();
        for (int i = 0; i < wave.monsterInfos.Length; i++)
        {
            EnemyIcon ic = Instantiate(enemyIconPrefab, layout.transform.position, Quaternion.identity, layout).GetComponent<EnemyIcon>();

            if (wave.monsterInfos[i].isRandom)
                ic.SetupEnemyIcon(random, wave.amoutOfEnemyForEachType[i], wave.monsterInfos[i]);
            else
                ic.SetupEnemyIcon(wave.monsterInfos[i].headPrefab.sprite, wave.amoutOfEnemyForEachType[i], wave.monsterInfos[i]);
            icons.Add(ic);
        }
    }

    public void UpdateInfo(int currentWavePart, int currentEnemyLeft)
    {
        icons[currentWavePart].UpdateAmount(currentEnemyLeft);

        if(currentEnemyLeft == 0)
        {
            icons[currentWavePart].gameObject.SetActive(false);
            icons[currentWavePart].enemyInfoTable.SetTabelView(false);
        }

    }
}
