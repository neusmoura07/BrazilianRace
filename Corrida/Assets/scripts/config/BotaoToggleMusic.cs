using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class BotaoToggleMusica : MonoBehaviour
{
    public Sprite imagemMusicaLigada; // Imagem quando a música está ativada
    public Sprite imagemMusicaDesligada; // Imagem quando a música está desativada
    public Image imagemToggle; // Referência à imagem do botão
    private GerenciadorDeMusica gerenciadorDeMusica; // Referência ao Gerenciador de Música

    void Start()
    {
        // Encontra o GerenciadorDeMusica na cena
        gerenciadorDeMusica = FindObjectOfType<GerenciadorDeMusica>();

        // Inicializa a imagem do botão com o estado inicial
        AtualizarImagemBotao();
    }

    // Método para alternar o estado da música
    public void AlternarMusica()
    {
        gerenciadorDeMusica.AlternarMusica(); // Alterna a música no Gerenciador de Música
        AtualizarImagemBotao(); // Atualiza a imagem do botão
    }

    // Atualiza a imagem do botão de acordo com o estado da música
    void AtualizarImagemBotao()
    {
        if (gerenciadorDeMusica.audioSource.isPlaying)
        {
            imagemToggle.sprite = imagemMusicaLigada;
        }
        else
        {
            imagemToggle.sprite = imagemMusicaDesligada;
        }
    }
}