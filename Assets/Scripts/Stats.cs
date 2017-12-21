using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats {

    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private DeathMenuCtrl deathMenu;

    [SerializeField]
    private WinMenuCtrl winMenu;

    private bool isDead;

    private bool chestFound;

    private int health;

    private int stars;

    public int Health {
        get
        {
            return health;
        }
        set
        {
            this.health = value;
            bar.healthAmount = value;
            if (health <= 0)
            {
                this.IsDead = true;
            }
        }
    }
    public int Stars
    {
        get
        {
            return stars;
        }
        set
        {
            this.stars = value;
            bar.starAmount = value;
        }
    }
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            this.isDead = value;
            if (value == true)
            {
                deathMenu.ShowMenu();
            }
        }
    }
    public bool ChestFound
    {
        get
        {
            return chestFound;
        }
        set
        {
            this.chestFound = true;
            winMenu.showMenu();
        }
    }




}
