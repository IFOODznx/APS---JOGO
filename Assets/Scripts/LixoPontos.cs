using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoPontos : MonoBehaviour
{
    public int valorPontos;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.totalPontos += valorPontos;
            GameController.instance.AtualizarPontos();
            Destroy(gameObject);
        }
    }
}
