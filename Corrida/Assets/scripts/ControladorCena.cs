using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCena : MonoBehaviour
{
    public void IniciarNivel(int id)
    {
        SceneManager.LoadScene(id);
    }
}