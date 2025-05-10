using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float maxHp;
    public float hp;

    [Header("Scale")]
    private GameObject scale;
    public float startScale = 1f;
    public float currentScale;

    private void UpdateScale()
    {
        currentScale = hp * startScale / maxHp;
        scale.transform.localScale = new Vector3(currentScale, 1, 1);
    }
    private void Start()
    {

    }
    public void Setup(int health)
    {
        scale = transform.GetChild(0).gameObject;
        maxHp = health;
        hp = health;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        UpdateScale();

    }
}
