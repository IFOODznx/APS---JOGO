using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixeira : MonoBehaviour
{
    public int pontosAcerto;
    public int pontosErro;

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tagLixo = other.tag;
        string tagCorreta = "Lix_" + tagLixo;

        if (CompareTag(tagCorreta))
        {
            GameManager.instance.AdicionarPontos(pontosAcerto);
            //Debug.Log("Acertou!");
        }
        else
        {
            GameManager.instance.AdicionarPontos(pontosErro);
            //Debug.Log("Errou!");
        }

        Destroy(other.gameObject);
    }
}
