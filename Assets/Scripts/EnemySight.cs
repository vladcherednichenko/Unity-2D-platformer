using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    [SerializeField]
    private Enemy thisEnemy;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            thisEnemy.Target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            thisEnemy.Target = null;
        }
    }
}
