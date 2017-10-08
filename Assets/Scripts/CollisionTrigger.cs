using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {

    private BoxCollider2D characterCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

    // Use this for initialization
    void Start() {

        characterCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(characterCollider, platformCollider, true);
            //Debug.Log("enter");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //Debug.Log("exit");
            Physics2D.IgnoreCollision(characterCollider, platformCollider, false);
        }
    }
}
