using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadoFase {
    Bloqueado,
    Desbloqueado
}

public class GerenciadorProgresso : MonoBehaviour
{
    private const string CHAVE_PROGRESSO = "progresso";

    public static EstadoFase EstadoFase2 { get; set; } = EstadoFase.Bloqueado;
    public static EstadoFase EstadoFase3 { get; set; } = EstadoFase.Bloqueado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
