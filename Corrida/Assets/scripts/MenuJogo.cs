using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour {
    public Button botaoFase1;
    public Button botaoFase2;
    public Button botaoFase3;

    public Button botaoFase1Duplicado;
    public Button botaoFase2Duplicado;
    public Button botaoFase3Duplicado;

    void Start() {
        // Atualize o estado dos botões com base no progresso salvo
        AtualizarEstadoBotoes();
    }

    void AtualizarEstadoBotoes() {
        // Verifique o estado da Fase 2 e atualize a interação do botão
        if (GerenciadorProgresso.EstadoFase2 == EstadoFase.Desbloqueado) {
            botaoFase2.interactable = true;
            botaoFase2Duplicado.interactable = true;
        } else {
            botaoFase2.interactable = false;
            botaoFase2Duplicado.interactable = false;
        }

        // Verifique o estado da Fase 3 e atualize a interação do botão
        if (GerenciadorProgresso.EstadoFase3 == EstadoFase.Desbloqueado) {
            botaoFase3.interactable = true;
            botaoFase3Duplicado.interactable = true;
        } else {
            botaoFase3.interactable = false;
            botaoFase3Duplicado.interactable = false;
        }
    }

}
