using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GerenciadorJogo gerenciadorJogo; // Referência ao script do GerenciadorJogo

    void Update()
    {
        // Verifica se o jogador pressionou a tecla "Escape" para pausar/despausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Só permite pausar se a corrida já começou e o temporizador foi finalizado
            if (gerenciadorJogo.jogoIniciado && gerenciadorJogo.temporizadorFinalizado)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
    Debug.Log("Jogo retomado. Time.timeScale: " + Time.timeScale);
}

public void Pause()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;
    Debug.Log("Jogo pausado. Time.timeScale: " + Time.timeScale);
}
}