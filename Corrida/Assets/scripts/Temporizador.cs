using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public float tempoInicial = 5f; // Tempo inicial do temporizador
    private float tempoRestante;
    private bool jogoIniciado = false;
    public Text textoTemporizador;

    public GameObject objetoParaExcluir; // GameObject que será excluído ao finalizar o tempo

    void Start()
    {
        tempoRestante = tempoInicial;
        Time.timeScale = 0f; // Congela o tempo no início
        AtualizarTemporizador();
    }

    void Update()
    {
        if (!jogoIniciado)
        {
            tempoRestante -= Time.unscaledDeltaTime; // Decrementa o tempo sem considerar a escala do tempo
            AtualizarTemporizador();

            if (tempoRestante <= 0)
            {
                Time.timeScale = 1f; // Retorna o tempo ao normal
                jogoIniciado = true;

                // Destroi o GameObject especificado ao finalizar o tempo
                Destroy(objetoParaExcluir);
            }
        }
    }

    void AtualizarTemporizador()
    {
        int segundos = Mathf.CeilToInt(tempoRestante);
        textoTemporizador.text = segundos.ToString();
    }
}