using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    public Text health;
    [SerializeField]
    public Text stars;

    public static int healthDef = 10;
    public static int starDef = 3;

    public int healthAmount { get; set; }
    public int starAmount { get; set; }

	// Use this for initialization
	void Start () {

        healthAmount = healthDef;
        starAmount = starDef;

    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
    }

    private void HandleBar()
    {
        health.text = healthAmount.ToString();
        stars.text = starAmount.ToString();
    }

}
