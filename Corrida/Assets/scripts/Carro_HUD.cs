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
            
            veloKMH.text = string.Format("{0:0}",carro.veloKMH) + "KM/H";

            Vector3 rotAgulha = agulhaRPM.rotation.eulerAngles;

            newR = Mathf.Lerp(newR, carro.rpm, 0.3f); 

            rotAgulha.z = ((newR*180f)/carro.maxRPM)* -1f ;

            agulhaRPM.eulerAngles = rotAgulha;

            volta.text = (carro.voltas+1).ToString() + "/" + numVoltas;


        }

        public void ReceberPosicao(int pos)
        {
            posicao.text = pos+"º";
            this.pos = pos;
        }

        public void ReceberHUD(RectTransform rect, Text velo, Text pos, Text volta, int numVoltas)
        {
            agulhaRPM = rect;
            veloKMH = velo;
            posicao = pos;
            this.volta = volta;
            this.numVoltas = numVoltas;
            setup = true;
        }
    
}
