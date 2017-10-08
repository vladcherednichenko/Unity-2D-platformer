using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public static Player instance;

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float jumpForce = 700;

    [SerializeField]
    private float groundRadius = 0.2f;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletPosition;

    [SerializeField]
    private PolygonCollider2D swordCollider;

    private Vector2 spawn;

    private float xspeed;
    private int movingDirection;

    public int EnemyAmount = 3;
    public int EnemyKilled;

    protected Player()
    {
    }

    public Rigidbody2D PlayerRigidBody { get; set;}
    public bool Dodge { get; set; }
    public bool Shoot { get; set; }
    public bool Jump { get; set; }
    public bool OnGround { get; set; }

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    // Use this for initialization
    protected override void Start () {

        EnemyKilled = 0;

        swordCollider.enabled = false;

        base.Start();

        spawn = transform.position;

        PlayerRigidBody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    void FixedUpdate()
    {

        if (!IsDead)
        {
            //проверь, нужно ли это присваивание
            movingDirection = 0;

            xspeed = Input.GetAxis("Horizontal");

            flip();

            OnGround = IsGrounded();

            handleInput();

            handleMovement(xspeed);

            handleLayers();

        }

    }

    public void MeleeAttack()
    {
        swordCollider.enabled = !swordCollider.enabled;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.name == "DieCollider")
        {
            transform.position = spawn;
        }

    }

    private void handleInput()
    {

        if (Input.GetKey(KeyCode.RightArrow) && xspeed > 0) movingDirection = 1;

        if (Input.GetKey(KeyCode.LeftArrow) && xspeed < 0) movingDirection = -1;

        if (Input.GetKeyDown(KeyCode.R))
        {
            CharacterAnimator.SetTrigger("attack");

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            CharacterAnimator.SetTrigger("shoot");

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CharacterAnimator.SetTrigger("dodge");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            CharacterAnimator.SetTrigger("jump");

        }

    }

    private void handleMovement(float xspeed)
    {

        if (PlayerRigidBody.velocity.y < 0 )
        {
            CharacterAnimator.SetBool("land", true);
        }
        if (!Attack && !Shoot && !Dodge)
        {
            PlayerRigidBody.velocity = new Vector2(runSpeed * movingDirection, PlayerRigidBody.velocity.y);
        }
        if (Jump && OnGround)
        {
            PlayerRigidBody.AddForce(new Vector2(0, jumpForce));
        }

        CharacterAnimator.SetFloat("speed", Mathf.Abs(movingDirection));

        
    }

    private void handleLayers()
    {
        if (!OnGround)
        {
            CharacterAnimator.SetLayerWeight(1, 1);
        }

        else CharacterAnimator.SetLayerWeight(1, 0);
    }

    private void flip()
    {
        if (xspeed < 0 && facingRight || xspeed > 0 && !facingRight)
        {
            changeDirection();

        }
    }

    private bool IsGrounded()
    {

        if (Mathf.Abs(PlayerRigidBody.velocity.y) <= 0.1)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }

        return false;

    }

    private void shoot(int value)
    {

        if (facingRight)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition.position, Quaternion.Euler(0,0,0));

            bullet.GetComponent<Bullet>().setDirection(Vector2.right);
            
        }
        else
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition.position, Quaternion.Euler(0,0,180));

            bullet.GetComponent<Bullet>().setDirection(Vector2.left);
        }
    }

    public override IEnumerator TakeDamage()
    {
        health -= 1;

        if (health == 0)
        {
            CharacterAnimator.SetLayerWeight(1,0);
            CharacterAnimator.SetTrigger("die");
        }
        if (health > 0)
        {
            CharacterAnimator.SetTrigger("damage");

        }
        yield return null;
    }

    void OnGUI()
    {
        if (IsDead)
            GUI.TextField(new Rect(300, 100, 100, 50), "you loose");



        GUI.TextField(new Rect(0,0, 119, 100), "Enemies left: " + (EnemyAmount - EnemyKilled) + "\n " + " F - shoot" + "\n" + "  R - attack");

        if (EnemyAmount - EnemyKilled == 0)
        {
            GUI.TextField(new Rect(300, 100, 100, 100), "you win");
        }
    }
}
