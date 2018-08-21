using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    Image hpbar;
    public float maxhp;
    public static float health;

	// Use this for initialization
	void Start () {

        GameObject imageObject = GameObject.FindGameObjectWithTag("hp");
        if (imageObject != null)
        {
           hpbar = imageObject.GetComponent<Image>();
        }

        health = maxhp;
	}
	
	// Update is called once per frame
	void Update () {
       hpbar.fillAmount = health / maxhp;
	}
}
