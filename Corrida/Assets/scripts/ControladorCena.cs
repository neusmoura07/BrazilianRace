using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCena : MonoBehaviour
{
    public void IniciarNivel(int sceneName)
    {
        Time.timeScale = 1f; // Despausa o jogo
        GlobalLoadManager.Instance.LoadScene(sceneName);
    }

    public void FecharJogo()
    {
        Debug.Log("Fechando o jogo...");
        Application.Quit();
    }
}