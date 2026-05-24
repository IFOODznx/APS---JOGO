using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : MonoBehaviour
{
    //Publicas
    public float velocidade;
    public bool direcaoDireita; // Se ativado, vira o Sprite para a direito. Se desativado, vira o Sprite para a esquerda
    public float tempoMovimento; // Tempo que o mosquito leva para mudar de direção
    public float kikanoInimigo; // Força do pulo do inimigo

    //Privadas
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movimento();
    }

    void Movimento()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        if(direcaoDireita)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        timer += Time.deltaTime;
        if(timer >= tempoMovimento)
        {
            direcaoDireita = !direcaoDireita;
            timer = 0f;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.contacts[0];

            if(contact.normal.y < -0.5f)
            {
                // Se o jogador colidir com a parte superior do mosquito, ele é "kikado" para cima
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                        playerRb.velocity = new Vector2(
                        playerRb.velocity.x,
                        kikanoInimigo
                        );
                }

                velocidade = 0f;
                boxCollider.enabled = false;
                //rb.isKinematic = true;
                Destroy(gameObject);
            }
            else
            {
                GameController.instance.GameOver();
                Destroy(collision.gameObject);
            } 
        }
    }
}
