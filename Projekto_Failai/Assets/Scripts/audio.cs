using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {

    public AudioSource[] sounds;
    public AudioSource noise1;


    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D))
        {

                noise1.Play();
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {

            noise1.Stop();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            noise1.Play();
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {

            noise1.Stop();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            noise1.Play();
        }

        else if (Input.GetKeyUp(KeyCode.W))
        {

            noise1.Stop();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            noise1.Play();
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {

            noise1.Stop();
        }

    }
}
