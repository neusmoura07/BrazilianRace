using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro_AI : MonoBehaviour
{
    Waypoint[] listaWaypoints;

    Carro carro;

    int atual = 0;

    float virar = 0;

    float agressividade = 0f;

    private void Start()
    {
        GameObject parentWaypoints = GameObject.Find("WAYP");

        listaWaypoints = parentWaypoints.GetComponentsInChildren<Waypoint>();

        carro = GetComponent<Carro>();

        agressividade = Random.Range(-12f, 4f);
    }

    private void FixedUpdate()
    {
        if (listaWaypoints[atual].velocidadeRecomendada+agressividade > carro.veloKMH)
        {
            carro.acc = 1f;
        }
        else
        {
            carro.acc = -1;
        }

        Vector3 dir = transform.InverseTransformPoint(new Vector3(listaWaypoints[atual].transform.position.x,transform.position.y, listaWaypoints[atual].transform.position.z));

        virar = Mathf.Clamp((dir.x/dir.magnitude) * 10f, -1, 1f);

        carro.gui = virar;

        if (Vector3.Distance(transform.position,listaWaypoints[atual].transform.position) < 10f)
        {
            atual++;
            if (atual == listaWaypoints.Length)
            {
                atual = 0;
            }
        }
    }
    
}
