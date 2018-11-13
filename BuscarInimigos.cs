using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscarInimigos : MonoBehaviour {

    public int distanciaInimigo;
    public int contadorInimigos;

	// Use this for initialization
	void Start () {
        for (int i = 0; i <= 5; i++)
        {
            contadorInimigos = 5;
            VerificaInimigos();
            distanciaInimigo = Random.Range(1, 10);
            Debug.Log("A distancia do inimigo e :" + distanciaInimigo);
            if (distanciaInimigo < 2)
            { 
                Debug.Log("Cuidado");
            }
           
        }
	}

    void VerificaInimigos()
    {

       while (contadorInimigos > 0 )
        {
            Debug.Log("Inimigo Verificado");
             contadorInimigos--; // contadorInimigos = contadorInimigos - 1;
           

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
