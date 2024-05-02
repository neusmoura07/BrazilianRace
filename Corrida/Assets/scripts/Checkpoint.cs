using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public List<Volta> voltas;

    private void Start()
    {
        voltas = new List<Volta>();
        for(int i = 0; i < 3; i++)
        {
            voltas.Add(new Volta());
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
       Carro c = other.transform.root.GetComponent<Carro>();

       RegistrarCarro(c,c.voltas);

       Carro_HUD cHUD = other.transform.root.GetComponent<Carro_HUD>();

       if (cHUD != null)
       {
        cHUD.ReceberPosicao(RetornarPosicao(c, c.voltas)+1);
       }

    }

    public bool PassouCarro(Carro c, int volta)
    {

        for (int i =0; i < voltas[volta].carros.Count;i++)
        {
            if(voltas[volta].carros[i] ==c)
            {
                return true;
            }
        }
        return false;
    }

    public bool RegistrarCarro(Carro carro, int volta)
    {

        voltas[volta].carros.Add(carro);
        return true;
    }

    public int RetornarPosicao(Carro carro, int volta)
    {
        for (int i =0; i < voltas[volta].carros.Count;i++)
        {
            if (voltas[volta].carros[i] == carro)
            {
                return i;
            }
        }

        return -1;
    }
}

public class Volta 
{
    public List<Carro> carros;
    public Volta()
    {
        carros = new List<Carro>();
    }
}
