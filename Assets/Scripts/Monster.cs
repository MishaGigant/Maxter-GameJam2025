using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform bodyPosition;
    public ConveyorItem hat, head, body;
    public Dictionary<NormalStats, int> monsterStats = new Dictionary<NormalStats, int>
    {
        {NormalStats.Health, 0},
        {NormalStats.Speed, 0},
        {NormalStats.Damage, 0},
        {NormalStats.AttackSpeed, 0},
        {NormalStats.CritChance, 0},
        {NormalStats.CritDamage, 0},
    };

    public enum Team { Player, Enemy }
    public Team team;
    public float attackRange = 1f;
    public float attackRate = 2f;

    public LayerMask entityLayer;

    public Transform rayDetectionPos;

    [SerializeField]private bool isMoving = true;
    [SerializeField] private bool isAttacking = false;
    private bool facingRight;
    private float timeBtwAttack = 2f;
    public Animator animator;
    private Monster currentTarget;
    public void Start()
    {

        attackRange = 3f;
        timeBtwAttack = attackRate;

        if (team == Team.Player)
            facingRight = true;
        else if (team == Team.Enemy)
            facingRight = false;

        if (!facingRight)
            Flip();
        // �������� ��������
        isMoving = true;
        isAttacking = false;
    }
    private void Update()
    {
        if (isAttacking)
        {
            if (timeBtwAttack <= 0)
                AttackTarget();
            else
                timeBtwAttack -= Time.deltaTime;
            return;
        }
        // �������� ����� ����� � ������� Raycast
        CheckForObstacles();
        if (!isMoving) return;

        // �������� ���������
        float moveDirection = facingRight ? 1 : -1;
        transform.Translate(Vector2.right * (moveDirection * monsterStats[NormalStats.Speed] * Time.deltaTime));

    }

    private void CheckForObstacles()
    {
        Vector2 rayDirection = facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(rayDetectionPos.position, rayDirection, attackRange, entityLayer);

        if (hit.collider != null)
        {
            Monster otherMonster = hit.collider.GetComponentInParent<Monster>();

            if (otherMonster != null)
            {
                if (otherMonster.team != team) // ���������
                {
                    isMoving = false;
                    //animator.SetBool("isMoving", false);
                    currentTarget = otherMonster;
                    isAttacking = true;
                }
                else // �������
                {
                    // ����� �� �����, ���� ������� �� ����
                    isMoving = false;
                    //animator.SetBool("isMoving", false);
                }
            }
        }
        else // ������ ��� ����� ����
        {
            isMoving = true;
            isAttacking = false;
            //animator.SetBool("isMoving", true);
        }
    }

    private void AttackTarget()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", true);
    }
    public void DealDamage()
    {
        currentTarget.TakeDamage(this);
    }
    public void ResetAttack()
    {
        timeBtwAttack = attackRate;
        animator.SetBool("isAttacking", false);
    }

    public void TakeDamage(Monster attacker)
    {
        monsterStats[NormalStats.Health] -= attacker.monsterStats[NormalStats.Damage];

        if (monsterStats[NormalStats.Health] <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // ����� �������� ������� ������, �������� � �.�.
        Destroy(gameObject);
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ��� ������������ Raycast � ���������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 rayDirection = facingRight ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(rayDetectionPos.position, rayDetectionPos.position + (Vector3)rayDirection * attackRange);
    }

    public void MakeMonster(ConveyorItem hatToSet, ConveyorItem headToSet, ConveyorItem bodyToSet)
    {
        body = Instantiate(bodyToSet, bodyPosition.position, Quaternion.identity, this.transform);
        SetStats(bodyToSet);
        body.isCreated = true;
        rayDetectionPos = body.rayCastPoint;
        animator = body.GetComponent<Animator>();

        head = Instantiate(headToSet, body.connector.position, Quaternion.identity, this.transform);
        SetStats(headToSet);
        head.isCreated = true;

        hat = Instantiate(hatToSet, head.connector.position, Quaternion.identity, this.transform);
        SetStats(hatToSet);
        hat.isCreated = true;

        for (int i = 0; i < monsterStats.Count; i++)
        {
            Debug.Log((NormalStats)i + " is " + monsterStats[(NormalStats)i]);
        }


        if (team == Team.Player)
            facingRight = true;
        else if (team == Team.Enemy)
            facingRight = false;

        if (!facingRight)
            Flip();
        // �������� ��������
        isMoving = true;
        isAttacking = false;
    }
    public void SetStats(ConveyorItem item)
    {
        monsterStats[item.itemStats.firstStat] += item.itemStats.firstStatValue;
        monsterStats[item.itemStats.secondStat] += item.itemStats.secondStatValue;
        monsterStats[item.itemStats.randomStat] += item.itemStats.randomStatValue;
    }

}
