using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introducao : MonoBehaviour
{
    private ControladorCena controladorCena;

    void Start()
    {
        controladorCena = FindObjectOfType<ControladorCena>();
    }

    void Update()
    {
        // Verifica se uma tecla foi pressionada ou se ocorreu um clique do mouse
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            // Carrega a cena do menu
            controladorCena.IniciarNivel(2);
        }
    }
}