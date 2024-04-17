using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        painel.transform.GetChild(2).GetComponent<Text>().text = posicao+"º";
        painel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate
        {

            if (posicao == 1)
            {
                controlador.dinheiro += 5000;
            }
            SceneManager.LoadScene(0);
            
        });
    }
    
}
