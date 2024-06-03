using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimCorrida : MonoBehaviour
{
    public GameObject painel;
    Controlador controlador;

    private void Start()
    {
        controlador = FindObjectOfType<Controlador>();
    }

    public void MostrarPainel(int posicao)
    {
        painel.SetActive(true);
        painel.transform.GetChild(0).GetComponent<Text>().text = posicao + "º";

        string sceneName = SceneManager.GetActiveScene().name;

    if (posicao == 1 && sceneName == "Mapa1")
    {
        //controlador.dinheiro += 5000;
        GerenciadorProgresso.EstadoFase2 = EstadoFase.Desbloqueado; // Desbloqueia a Fase 2 ao vencer a corrida na Fase 1
    }
    else if (posicao == 1 && sceneName == "Mapa2")
    {   
        //controlador.dinheiro += 5000;
        GerenciadorProgresso.EstadoFase3 = EstadoFase.Desbloqueado; // Desbloqueia a Fase 3 ao vencer a corrida na Fase 2
    }
    else if (posicao == 1 && sceneName == "Mapa3")
    {
        //controlador.dinheiro += 5000;
    }
        StartCoroutine(congelatelafim());
    }

    IEnumerator congelatelafim()
    {
        yield return new WaitForSeconds(2f); // Aguarda 2 segundos

        // Congela o jogo
        Time.timeScale = 0f;
    }
    
}
