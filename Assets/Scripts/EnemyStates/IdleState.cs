using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState {

    private Enemy thisEnemy;

    private float idleTimer;

    private float idleDuration = 7;

    public void Enter(Enemy enemy)
    {
        thisEnemy = enemy;
    }

    public void Execute()
    {

        if (thisEnemy.Target != null)
        {
            thisEnemy.ChangeState(new PatrolState());
        }

        Idle();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    public void Idle()
    {
        thisEnemy.CharacterAnimator.SetFloat("speed", 0);

        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            thisEnemy.ChangeState(new PatrolState());
        }
    }
}
