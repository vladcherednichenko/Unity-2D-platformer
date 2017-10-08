using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Animator CharacterAnimator { get; private set;}

    [SerializeField]
    protected int health;

    [SerializeField]
    protected float runSpeed = 20;

    [SerializeField]
    private List<string> damadeSources;

    protected bool facingRight;

    public bool Attack { get; set; }

    public abstract bool IsDead { get; }

    // Use this for initialization
    protected virtual void Start () {

        facingRight = true;

        CharacterAnimator = GetComponent<Animator>();

    }
	
    public virtual void changeDirection()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    public abstract IEnumerator TakeDamage();

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

        if (damadeSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
        

    }
}
