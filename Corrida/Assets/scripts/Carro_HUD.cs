using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carro_HUD : MonoBehaviour
{
    Carro carro;

    public RectTransform agulhaRPM;
    public Text veloKMH;

    public Text posicao;
    public Text volta;
    public int numVoltas;

    float newR;

    bool setup = false;

    public int pos;
    public Text marcha;

    void Start()
    {
        carro = GetComponent<Carro>();

    }

    void FixedUpdate()
    {
        if (!setup)
        {
            return;
        }

        // Atualiza a velocidade do texto
        veloKMH.text = string.Format("{0:0}", carro.veloKMH) + "KM/H";

        // Obter a velocidade máxima da marcha atual
        float velocidadeMaximaAtual = carro.limitesDeVelocidade[carro.mudancaAtual];

        // Suaviza a rotação da agulha
        newR = Mathf.Lerp(newR, carro.veloKMH, 0.3f);

        // Calcula o ângulo da agulha baseado na velocidade atual e velocidade máxima da marcha atual
        float rotacaoAgulhaZ = ((newR * 150) / velocidadeMaximaAtual) * -1f;

        // Limita a rotação da agulha entre um mínimo e um máximo
        float anguloMinimo = -190f; // Ajuste conforme necessário
        float anguloMaximo = 60f;    // Ajuste conforme necessário
        rotacaoAgulhaZ = Mathf.Clamp(rotacaoAgulhaZ, anguloMinimo, anguloMaximo);

        // Atualiza a rotação da agulha
        Vector3 rotAgulha = agulhaRPM.rotation.eulerAngles;
        rotAgulha.z = rotacaoAgulhaZ;
        agulhaRPM.eulerAngles = rotAgulha;

        // Atualiza o texto de voltas e marcha
        volta.text = (carro.voltas).ToString() + "/" + numVoltas;
        marcha.text = (carro.mudancaAtual + 1).ToString();

        // Verifica se a velocidade está na zona vermelha
        if (carro.veloKMH >= velocidadeMaximaAtual * 0.9f)
        {
            // Mudar a cor do texto da velocidade para vermelho
            veloKMH.color = Color.red;
        }
        else
        {
            // Manter a cor padrão
            veloKMH.color = Color.black;
        }   
    }

        

        public void ReceberPosicao(int pos)
        {
            posicao.text = pos+"º";
            this.pos = pos;
        }

        public void ReceberHUD(RectTransform rect, Text velo, Text pos, Text volta, int numVoltas, Text marcha)
        {
            agulhaRPM = rect;
            veloKMH = velo;
            posicao = pos;
            this.volta = volta;
            this.numVoltas = numVoltas;
            this.marcha = marcha;
            setup = true;
        }
    
}
