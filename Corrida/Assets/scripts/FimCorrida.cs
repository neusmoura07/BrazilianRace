using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimCorrida : MonoBehaviour
{
    public GameObject painel;
    Controlador controlador;

    private void Start()
    {
        controlador = FindObjectOfType<Controlador>();
    }

    public void MostrarPainel(int posicao)
    {
        painel.SetActive(true);
        painel.transform.GetChild(0).GetComponent<Text>().text = posicao+"º";
        if (posicao == 1)
            {
                controlador.dinheiro += 5000;
            }
    }
    
}
