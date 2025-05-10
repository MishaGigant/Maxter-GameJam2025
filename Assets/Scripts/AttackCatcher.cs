using UnityEngine;

public class AttackCatcher : MonoBehaviour
{
    public Monster monster;

    public void DealDamage()
    {
        monster.DealDamage();
    }
    public void ResetAttack()
    {
        monster.ResetAttack();
    }
}
