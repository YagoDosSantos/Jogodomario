using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject PainelCompleto;
    public GameObject imagepause;

    public bool isPaused = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
    public void pause()
    {
        if (isPaused)
        {
            PainelCompleto.SetActive(false);
            imagepause.SetActive(false);
            isPaused = false;
        }
        else
        {
            PainelCompleto.SetActive(true);
            imagepause.SetActive(true);
            isPaused = true;


        }
    }
}
