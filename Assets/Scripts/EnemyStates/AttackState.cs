using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private float runSpeed = 4;
    private Enemy thisEnemy;

    private float attackTimer;
    private float attackCooldown = 0.5f;
    private bool canAttack;

    public void Enter(Enemy enemy)
    {
        this.thisEnemy = enemy;
    }

    public void Execute()
    {

        if (thisEnemy.Target != null)
        {
            thisEnemy.Move(runSpeed);
        }
        else
        {
            thisEnemy.ChangeState(new IdleState());
        }

        if (thisEnemy.InMeleeRange) Attack();
        
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            thisEnemy.ChangeState(new IdleState());

        }
    }

    private void Attack()
    {

        if (attackTimer == 0)
        {
            canAttack = true;

        }

        attackTimer += Time.deltaTime;

        if (attackTimer > attackCooldown)
        {
            attackTimer = 0;
        }

        if (canAttack)
        {
            canAttack = false;
            thisEnemy.CharacterAnimator.SetTrigger("attack");
        }


    }
}
