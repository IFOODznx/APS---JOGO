using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPonto : MonoBehaviour
{
    public int ponto;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.totalPontos += ponto;
            GameController.instance.AtualizarPontos();
            Destroy(gameObject);
        }
    }
}
