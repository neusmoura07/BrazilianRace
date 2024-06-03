using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorJogo : MonoBehaviour
{
    public float tempoInicial = 5f; // Tempo inicial do temporizador
    private float tempoRestante;
    public bool jogoIniciado = false; // Mantendo jogoIniciado público para acesso do MenuPausa
    public bool temporizadorFinalizado = false; // Indica se o temporizador foi concluído
    public Text textoTemporizador;

    public Image cutsceneImage; // Referência para o componente Image do Canvas
    public Sprite[] cutsceneSprites; // Array de sprites para as cutscenes
    private int cutsceneIndex = 0;

    public GameObject objetoParaExcluir; // GameObject que será excluído ao finalizar o tempo

    void Start()
    {
        // Congela o jogo ao iniciar as cutscenes
        Time.timeScale = 0f;

        // Inicializa a primeira cutscene
        if (cutsceneSprites.Length > 0)
        {
            cutsceneImage.sprite = cutsceneSprites[0];
            cutsceneImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Nenhuma sprite de cutscene encontrada.");
            TerminarCutscene();
        }

        // Inicializa o temporizador
        tempoRestante = tempoInicial;
        AtualizarTemporizador();
    }

    void Update()
    {
        if (!jogoIniciado)
        {
            // Avança para a próxima cutscene ao pressionar a tecla Espaço
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AvancarCutscene();
            }
        }
        else if (!temporizadorFinalizado)
        {
            // Temporizador
            tempoRestante -= Time.unscaledDeltaTime; // Decrementa o tempo sem considerar a escala do tempo
            AtualizarTemporizador();

            if (tempoRestante <= 0)
            {
                Time.timeScale = 1f;
                temporizadorFinalizado = true;

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

    void AvancarCutscene()
    {
        cutsceneIndex++;
        if (cutsceneIndex < cutsceneSprites.Length)
        {
            cutsceneImage.sprite = cutsceneSprites[cutsceneIndex];
        }
        else
        {
            // Todas as cutscenes foram exibidas, então desativa o Canvas e inicia o temporizador
            TerminarCutscene();
        }
    }

    void TerminarCutscene()
    {
        cutsceneImage.gameObject.SetActive(false);
        IniciarTemporizador();
    }

    // Método para iniciar o temporizador
    void IniciarTemporizador()
    {
        jogoIniciado = true;
        tempoRestante = tempoInicial;
        AtualizarTemporizador();
        // Não altere o Time.timeScale aqui. Ele deve ser alterado somente no menu de pausa ou quando necessário.
    }
}