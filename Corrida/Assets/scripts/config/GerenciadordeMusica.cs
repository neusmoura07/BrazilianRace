using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMusica : MonoBehaviour
{
    private static GerenciadorDeMusica instancia;

    public AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para alternar a música
    public void AlternarMusica()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}