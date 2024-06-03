using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVeiculos : MonoBehaviour
{
    public GameObject[] carrosAI;
    public GameObject[] carrosJogador;
    private List<int> indicesCarrosDisponiveis = new List<int>();


    private void Awake()
    {
        // Preencher a lista com os índices dos carros disponíveis
        for (int i = 0; i < carrosAI.Length; i++)
        {
            indicesCarrosDisponiveis.Add(i);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 1)
            {
                // Spawn do carro do jogador
                int indexCarro = Random.Range(0, carrosJogador.Length);
                Instantiate(carrosJogador[indexCarro], 
                            transform.GetChild(i).position, 
                            Quaternion.Euler(transform.GetChild(i).localEulerAngles));
            }
            else
            {
                // Spawn de um carro AI aleatório
                int indexCarro = Random.Range(0, indicesCarrosDisponiveis.Count);
                Instantiate(carrosAI[indicesCarrosDisponiveis[indexCarro]], 
                            transform.GetChild(i).position, 
                            Quaternion.Euler(transform.GetChild(i).localEulerAngles));
                
                // Remover o índice correspondente ao carro spawnado
                indicesCarrosDisponiveis.RemoveAt(indexCarro);
            }
        }
    }
}
