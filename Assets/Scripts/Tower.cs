using UnityEngine;

public class Tower : Monster
{
    public override void Die()
    {
        base.Die();
        if (team == Team.Player)
            Debug.Log("�� ��������");
        else
            Debug.Log("���! ������!");
    }
}
