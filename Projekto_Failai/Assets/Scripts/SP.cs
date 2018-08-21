using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SP : MonoBehaviour {

    Image spbar;
    public float maxsp;
    public static float special;

    // Use this for initialization
    void Start()
    {

        GameObject imageObject = GameObject.FindGameObjectWithTag("sp");
        if (imageObject != null)
        {
            spbar = imageObject.GetComponent<Image>();
        }

        special = maxsp;
    }

    // Update is called once per frame
    void Update()
    {
        spbar.fillAmount = special / maxsp;
    }
}
