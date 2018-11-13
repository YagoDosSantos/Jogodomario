using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public bool colidde = false;

    private float move = -2;

    void Start()
    {
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if (colidde)
        {
            Flip();
        }
    }

    private void Flip()
    {
        move *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        colidde = false;
    }

    void OnCollisionEnter2D(Collision col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
            colidde = true;
        }
    }

    void OnCollisionExit2D(Collision col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
            colidde = false;
        }
    }



}
