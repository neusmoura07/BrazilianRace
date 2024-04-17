using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{

    Checkpoint[] checkpoints;

    Controlador controlador;

    public FimCorrida fim;

    List<GameObject> acabaram;

    private void Awake() 
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        //CARREGAR OS CHECKPOINTS
        controlador = FindObjectOfType<Controlador>();

        acabaram = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Carro x = other.transform.root.GetComponent<Carro>();

        foreach (Checkpoint ch in checkpoints)
        {
            if (!ch.PassouCarro(x, x.voltas))
            {
                Debug.Log("VOLTA INVALIDADA");

    
                return;
            }
        }

        x.SomarVolta();

        if (x.voltas == controlador.numVoltas)
        {

            //ACABOU
            acabaram.Add(other.gameObject);
            
            if (x.GetComponent<Carro_AI>()==null)
            {
                //NOSSO CARRO
                //APARECER TABELA
                fim.MostrarPainel(acabaram.Count);

            }
        }
    }

    /*void ResetCheckpoints()
    {   
        foreach (Checkpoint cha in checkpoints)
                {
                    cha.carro = null;
                }


    }*/

}
