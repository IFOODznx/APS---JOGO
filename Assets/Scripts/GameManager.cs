using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int pontos = 0;

    public TextMeshProUGUI[] textoPontos;

    private void Awake()
    {
        instance = this;
    }

    public void AdicionarPontos(int valor)
    {
        pontos += valor;

        foreach (TextMeshProUGUI txt in textoPontos)
        {
            txt.text = "" + pontos;
        }
    }
}
