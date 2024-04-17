using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{

    public int dinheiro;

    public int numVoltas = 3;

    public bool existe = false;
    private void Awake()
    {
        if(!existe)
        {
            existe = !existe;
            DontDestroyOnLoad(gameObject);
        }
        else{
            DestroyImmediate(gameObject);
        }
        
    }
    
    
}
