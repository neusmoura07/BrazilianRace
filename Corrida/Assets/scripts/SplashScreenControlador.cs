using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SplashScreenControlador : MonoBehaviour
{

    private ControladorCena controladorCena;
    public float tempoDeExibicao = 3f; // Tempo de exibição em segundos

    private bool mostrouSplashScreen = false; // Flag para controlar se o SplashScreen já foi mostrado

    void Start()
    {
        controladorCena = FindObjectOfType<ControladorCena>();

        // Inicia a corrotina para desativar o SplashScreen após o tempo de exibição
        StartCoroutine(DesativarSplashScreen());
    
    }

    
    IEnumerator DesativarSplashScreen()
    {
        // Aguarda o tempo de exibição, a menos que seja zero ou menor
        if (tempoDeExibicao > 0)
        {
           yield return new WaitForSeconds(tempoDeExibicao);
        }

        // Carrega a próxima cena
        controladorCena.IniciarNivel(1);
    }
    
}
