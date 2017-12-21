using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuCtrl : MonoBehaviour {

    [SerializeField]
    public Transform UIcanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    public void ShowMenu()
    {
        Pause();

    }

    public void Pause()
    {
        UIcanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
