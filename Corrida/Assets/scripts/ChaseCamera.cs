using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    public Transform alvo; // O transform do veículo que a câmera vai seguir
    public Vector3 offsetPosicao; // A posição relativa à qual a câmera será mantida em relação ao veículo
    public float suavidade = 0.5f; // Quão suavemente a câmera seguirá o veículo
    public float suavidadeRotacao = 2f; // Quão suavemente a câmera se moverá para os lados

    private Vector3 posicaoAlvo; // Posição alvo da câmera
    private Vector3 velocidadeMovimento = Vector3.zero; // Velocidade de movimento da câmera
    private float inputHorizontal; // Entrada horizontal do teclado

    private void FixedUpdate()
    {
        if (alvo == null)
            return;

        // Captura a entrada horizontal do teclado
        inputHorizontal = Input.GetAxis("Horizontal");

        // Inverte a entrada horizontal para que as direções das teclas sejam opostas
        inputHorizontal *= -1f;

        // Calcula a posição alvo da câmera levando em conta a direção do veículo e a entrada horizontal
        posicaoAlvo = alvo.position - alvo.forward * offsetPosicao.z + alvo.up * offsetPosicao.y + alvo.right * inputHorizontal * suavidadeRotacao;

        // Move suavemente a câmera para a posição alvo
        transform.position = Vector3.SmoothDamp(transform.position, posicaoAlvo, ref velocidadeMovimento, suavidade);

        // Faz com que a câmera olhe para a traseira do veículo
        transform.LookAt(alvo.position);
    }
}

