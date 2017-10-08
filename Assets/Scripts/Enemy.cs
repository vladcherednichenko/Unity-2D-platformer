using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    IEnemyState currentState;

    [SerializeField]
    Collider2D leftCollider;

    [SerializeField]
    Collider2D rightCollider;

    [SerializeField]
    private float meleeRange;

    [SerializeField]
    private PolygonCollider2D zombieHandsCollider;

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {

                //Debug.Log(Vector2.Distance(transform.position, Target.transform.position));
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;

                
            }

            return false;
        }
    }

    public GameObject Target { get; set; }


    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    // Use this for initialization
    protected override void Start () {

        base.Start();

        zombieHandsCollider.enabled = false;

        ChangeState(new IdleState());

	}
	
	// Update is called once per frame
	void Update () {

        if (!IsDead)
        {
            currentState.Execute();

            LookAtTarget();
        }


	}


    public void MeleeAttack()
    {
        zombieHandsCollider.enabled = !zombieHandsCollider.enabled;
    }

    public void ChangeState(IEnemyState newState)
    {

        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    void LookAtTarget()
    {
        if (Target != null){

            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir > 0 && !facingRight || xDir <0 && facingRight)
            {
                changeDirection();
            } 
        }
        
    }

    public void Move(float speed)
    {
        if (!InMeleeRange)
        {
            CharacterAnimator.SetFloat("speed", 1);

            transform.Translate(GetDirection() * speed * Time.deltaTime);
        }
        else
            CharacterAnimator.SetFloat("speed", 0);


    }

    private Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        currentState.OnTriggerEnter(other);

    }

    public override IEnumerator TakeDamage()
    {
        health -= 1;

        if (health == 0)
        {
            CharacterAnimator.SetTrigger("die");
            Player.instance.EnemyKilled += 1;
        }
        if (health > 0)
        {
            CharacterAnimator.SetTrigger("damage");
            
        }
        yield return null;
    }

    //working only on even surfaces
    //need to be fixed

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.name != "Player")
    //    {
    //        changeDirection();
    //    }
    //}


}
