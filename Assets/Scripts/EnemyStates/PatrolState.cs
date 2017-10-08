using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

    private float patrolSpeed = 2;
    private Enemy thisEnemy;
    private float patrolTimer;
    private float patrolDuration = 4;


    public void Enter(Enemy enemy)
    {
        thisEnemy = enemy;
    }

    public void Execute()
    {

        Patrol();

        thisEnemy.Move(patrolSpeed);

        if (thisEnemy.Target != null)
        {
            thisEnemy.ChangeState(new AttackState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {

            thisEnemy.changeDirection();

        }

    }

    public void Patrol()
    {
        thisEnemy.CharacterAnimator.SetFloat("speed", 1);

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            thisEnemy.ChangeState(new IdleState());
        }
    }
}
