using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public float tempoInicial;
    private float tempoAtual;

    public bool cronometroAtivo = true;

    public TextMeshProUGUI textoCronometro;
    public GameObject PainelGameOver;
    public GameObject painelPassou;
    void Start()
    {
        tempoAtual = tempoInicial;
    }

    void Update()
    {
        if (cronometroAtivo)
        {
            if (tempoAtual > 0)
            {
                tempoAtual -= Time.deltaTime;

                if (tempoAtual < 0)
                {
                    tempoAtual = 0;
                }

                AtualizarTexto();
            }
            else
            {
                cronometroAtivo = false;

                PainelGameOver.SetActive(true); 
                textoCronometro.gameObject.SetActive(false);
                //Debug.Log("Tempo acabou!");
            }
        }
    }

    void AtualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tempoAtual / 60);
        int segundos = Mathf.FloorToInt(tempoAtual % 60);

        textoCronometro.text =
            minutos.ToString("00") + ":" +
            segundos.ToString("00");
    }
}
