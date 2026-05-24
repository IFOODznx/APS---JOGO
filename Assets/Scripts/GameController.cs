using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public int totalPontos;
    public TextMeshProUGUI textoPontos;
    public static GameController instance;
    public GameObject painelGameOver;
    public GameObject botoesMobile;

    public void AtualizarPontos()
    {
        textoPontos.text = totalPontos.ToString();
    }

    void Start()
    {
        instance = this;
    }

    public void GameOver()
    {
        painelGameOver.SetActive(true);
        botoesMobile.SetActive(false);
    }
    
    public void ReiniciarGame(String nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    
}
