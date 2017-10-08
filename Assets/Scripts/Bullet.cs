using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed = 10;

    private Rigidbody2D bulletRigidbody;

    private Vector2 direction;

	// Use this for initialization
	void Start () {

        bulletRigidbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame

    void FixedUpdate()
    {
        bulletRigidbody.velocity = direction * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
