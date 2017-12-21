using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1StateChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerDataCtrl.Entity.ChangeState(PlayerDataCtrl.Entity.stateLevel1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
