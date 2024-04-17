using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EncontrarCarroHUD : MonoBehaviour
{
    public RectTransform rect;
    public Text textoKMH;   
    public Text pos;
    public Text volta;

    Controlador controlador;

    private void Start()
    {
        controlador = FindObjectOfType<Controlador>();
        FindObjectOfType<Carro_HUD>().ReceberHUD(rect, textoKMH,pos,volta,controlador.numVoltas);
    }
}
