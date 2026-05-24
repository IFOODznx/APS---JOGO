using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(String nomeCena) //Função para carregar a cena do jogo
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void SairGame() //Função para sair do jogo
    {
        Application.Quit();
    }
}
