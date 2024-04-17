using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro_Input : MonoBehaviour
{

    Carro carro;
    // Start is called before the first frame update
    void Start()
    {
        carro = GetComponent<Carro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //chama o eixo pronto feito pela unity
        carro.gui = Input.GetAxis("Horizontal");
        carro.acc = Input.GetAxis("Vertical");
    }
}
