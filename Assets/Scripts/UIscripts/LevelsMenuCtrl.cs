using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuCtrl : MonoBehaviour {

    [SerializeField]
    private Text txt_tutorialStars;

    [SerializeField]
    private Text txt_level1Stars;

    [SerializeField]
    private Text txt_level2Stars;

    // Use this for initialization
    void Awake () {

        PlayerDataCtrl.Entity.Load();


        txt_tutorialStars.text = PlayerDataCtrl.Entity.data.tutorial.STARSGAINED.ToString() + "/" +
            PlayerDataCtrl.Entity.data.tutorial.STARS.ToString();

        txt_level1Stars.text = PlayerDataCtrl.Entity.data.level1.STARSGAINED.ToString() + "/" +
            PlayerDataCtrl.Entity.data.level2.STARS.ToString();

        txt_level2Stars.text = PlayerDataCtrl.Entity.data.level2.STARSGAINED.ToString() + "/" +
            PlayerDataCtrl.Entity.data.level2.STARS.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
