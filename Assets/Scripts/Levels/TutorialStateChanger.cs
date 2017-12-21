using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStateChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerDataCtrl.Entity.ChangeState(PlayerDataCtrl.Entity.stateTutorial);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
