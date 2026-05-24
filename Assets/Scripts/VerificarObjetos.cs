using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Esse script verifica os objetos filhos dentro do objeto vazio.

    Exemplo:
    Lixos (objeto vazio)
        -> Garrafa
        -> Jornal
        -> Casca de Banana

    Quando todos os filhos forem destruídos OU desativados:
    - o cronômetro para
    - aparece o painel de fase concluída
*/

public class VerificarObjetos : MonoBehaviour
{
    // Painel que aparece quando o jogador passa da fase
    public GameObject painelPassou;

    // Referência do script do cronômetro
    public Cronometro cronometro;

    void Update()
    {
        // Variável que começa assumindo que TODOS os objetos estão inativos
        bool todosInativos = true;

        // Percorre TODOS os filhos do objeto vazio
        foreach (Transform filho in transform)
        {
            // Se encontrar algum filho ativo
            if (filho.gameObject.activeSelf)
            {
                // Então ainda NÃO terminou
                todosInativos = false;

                // Para o loop para economizar processamento
                break;
            }
        }

        // Se TODOS os filhos estiverem inativos
        if (todosInativos)
        {
            // Para/congela o cronômetro
            cronometro.cronometroAtivo = false;

            //Debug.Log("Travou Cronometro");
        }

        // Verifica se NÃO existe mais nenhum filho dentro do objeto
        // Isso funciona quando os objetos são destruídos usando Destroy()
        if (transform.childCount == 0)
        {
            // Mostra o painel de vitória/passou da fase
            painelPassou.SetActive(true);

            // Carrega outra cena (desativado por enquanto)
            // SceneManager.LoadScene("Nivel_3");

            /*
                Outras coisas que você poderia fazer aqui:

                Debug.Log("os Lixos sumiram");
                porta.SetActive(true);
                Destroy(this);
            */
        }
    }
}