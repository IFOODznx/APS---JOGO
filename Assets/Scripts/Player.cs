using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configurações
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    // Controle de chão e pulo
    public bool estaNoChao;
    private bool podePuloDuplo;

    // Controle mobile
    private float movimento;
    private bool pular;

    // Componentes
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movimento();
        Pulo();
    }

    void Movimento()
    {
        float inputPC = Input.GetAxisRaw("Horizontal");

        // Junta input do PC + mobile
        float movimentoFinal = inputPC + movimento;

        // Limita entre -1 e 1
        movimentoFinal = Mathf.Clamp(movimentoFinal, -1f, 1f);

        // Movimento usando física
        rb.velocity = new Vector2(movimentoFinal * velocidade, rb.velocity.y);

        // Flip + animação
        if (movimentoFinal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("Andando", true);
        }
        else if (movimentoFinal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }
    }

    void Pulo()
    {
        // PC ou botão mobile
        if (Input.GetKeyDown(KeyCode.Space) || pular)
        {
            if (estaNoChao)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);

                estaNoChao = false;
                podePuloDuplo = true;
            }
            else if (podePuloDuplo)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);

                podePuloDuplo = false;
            }

            pular = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }

    // ===== Botões Mobile =====
    public void MovimentoDireita()
    {
        movimento = 1;
    }

    public void MovimentoEsquerda()
    {
        movimento = -1;
    }

    public void PararMovimento()
    {
        movimento = 0;
    }

    public void Pular()
    {
        pular = true;
    }
}
