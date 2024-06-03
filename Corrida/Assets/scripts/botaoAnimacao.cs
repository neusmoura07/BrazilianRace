using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoAnimacao : MonoBehaviour
{
    public Sprite imagemLigada; // Imagem quando está ativado
    public Sprite imagemDesligada; // Imagem quando está desativado
    public Image imagemToggle; // Referência à imagem do botão

    private bool estadoAtual = true; // Estado inicial, pode ser true (ligado) ou false (desligado)

    void Start()
    {
        // Inicializa a imagem do botão com o estado inicial
        AtualizarImagemBotao();
    }

    // Método para alternar o estado do botão
    public void AlternarEstado()
    {
        estadoAtual = !estadoAtual; // Alterna o estado
        AtualizarImagemBotao(); // Atualiza a imagem do botão
    }

    // Atualiza a imagem do botão de acordo com o estado
    void AtualizarImagemBotao()
    {
        if (estadoAtual)
        {
            imagemToggle.sprite = imagemLigada;
        }
        else
        {
            imagemToggle.sprite = imagemDesligada;
        }
    }
}
