using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuCtrl : MonoBehaviour {

    [SerializeField]
    public Transform UIcanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIcanvas.gameObject.activeInHierarchy == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
            
        }

	}

    public void CloseMenu()
    {
        Resume();
    }

    public void Pause()
    {
        UIcanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        UIcanvas.gameObject.SetActive(false);
    }
}
