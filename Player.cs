using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMaxima;

    public int Vidas;
    public int Moeda;

    public int text;
    public Text TextVidas;
    public Text TextMoeda;

    public bool isGrounded;
    public bool canfly;

    public bool isWater;





    void Start()
    {
        TextVidas.text = Vidas.ToString();
        TextMoeda.text = Moeda.ToString();

    }

    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);
        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (!isWater)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rigidbody.AddForce(new Vector2(0, forcaPulo));
                    GetComponent<AudioSource>().Play();
                    canfly = false;
                }
                else
                {
                    canfly = true;

                }

            }

            if (canfly && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Animator>().SetBool("flying", true);
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, -0.5f);
            }
            else
            {
                GetComponent<Animator>().SetBool("flying", false);
            }

            if (movimento > 0 || movimento < 0)
            {
                GetComponent<Animator>().SetBool("walke", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("walke", false);
            }

            if (isGrounded)
            {
                GetComponent<Animator>().SetBool("jump", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("jump", true);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rigidbody.AddForce(new Vector2(0, 6f * Time.deltaTime), ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rigidbody.AddForce(new Vector2(0, 06f * Time.deltaTime), ForceMode2D.Impulse);
            }

            rigidbody.AddForce(new Vector2(0, 10f * Time.deltaTime), ForceMode2D.Impulse);
        }

        GetComponent<Animator>().SetBool("flying", isWater);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetTrigger("walker");
            Collider2D[] colliders = new Collider2D[3];
            transform.Find("HammerArea").gameObject.GetComponent<Collider2D>()
                .OverlapCollider(new ContactFilter2D(), colliders);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null && colliders[i].gameObject.CompareTag("Monstros"))
                {
                    Destroy(colliders[i].gameObject);
                }
            }
        }
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            isWater = true;
        }
        if (collision.gameObject.CompareTag("Moeda"))
        {
            Destroy(collision.gameObject);
            Moeda++;
            TextMoeda.text = Moeda.ToString();

        }
        if (collision.gameObject.CompareTag("Vidas"))
        {
            Destroy(collision.gameObject);
            Vidas++;
            TextVidas.text = Vidas.ToString();

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            isWater = false;
        }
    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monstros"))
        {
            Vidas--;
            TextVidas.text = Vidas.ToString();
            if (Vidas == 0)
            {
                GameManager gamemaneger = new GameManager();

                //gamemaneger.isPaused = true;

                //gamemaneger.pause();

                gamemaneger.PainelCompleto.SetActive(true);
                gamemaneger.imagepause.SetActive(true);
                gamemaneger.isPaused = true;

            }
        }
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Trampolin"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);
        }
        Debug.Log("colidiu" + collision.gameObject.tag);
    }



    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = false;
        }

    }









}
