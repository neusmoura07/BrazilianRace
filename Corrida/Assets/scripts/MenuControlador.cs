using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControlador : MonoBehaviour
{
    Controlador controlador;
    public Text dinheiroText;
    public void IniciarNivel(int id)
    {
        SceneManager.LoadScene(id);
    }
    // Start is called before the first frame update
    private void Start()
    {
        controlador = FindObjectOfType< Controlador>();
        //AtualizarDinheiro();
    }

    /*public void AtualizarDinheiro()
    {
        dinheiroText.text = "Dinheiro: "+ controlador.dinheiro;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
