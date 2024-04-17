using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVeiculos : MonoBehaviour
{
    public GameObject[] carrosAI;
    public GameObject[] carrosJogador;


    private void Awake()
    {
        for(int i =0; i < transform.childCount; i++)
        {
            if (i == transform.childCount-1)
            {
                Instantiate(carrosJogador[0], transform.GetChild(i).transform.position, Quaternion.Euler(transform.GetChild(i).localEulerAngles));

                //INSTANCIAR JOGADOR EM ULTIMO
            }
            else{
                Instantiate(carrosAI[0], transform.GetChild(i).transform.position, Quaternion.Euler(transform.GetChild(i).localEulerAngles));
            }
        }
    }
}
