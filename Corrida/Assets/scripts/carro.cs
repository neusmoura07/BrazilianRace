using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carro : MonoBehaviour
{

    public WheelCollider[] guiar;

    float gui = 0f;
    float acc = 0f;

    Rigidbody rb;
    public AudioClip somcarro;
    public AudioSource audioCarro;
    public float maxTorque;

    public float forcaTravagem;

    float veloKMH;
    float rpm;

    public float[] racioMudancas;
    int mudancaAtual = 0;

    public float maxRPM;
    public float minRPM;
    public float somPitch;

    public Vector3 forcaFinal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioCarro.clip = somcarro;

    }

    // Update is called once per frame
    void Update()
    {
        //chama o eixo pronto feito pela unity
        gui = Input.GetAxis("Horizontal");
        acc = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //GUIAR
        //Entrar na lista e todos elementos vão fazer qualquer coisa, coloca um angulo na roda 
        for (int i = 0; i< guiar.Length; i++){
            guiar[i].steerAngle = gui * 15f;
            //adiciona uma pequena força nas rodas caso elas parem para facilitar a saida
            guiar[i].motorTorque = 1f;
        }
        //VELO E RPM
        veloKMH = rb.velocity.magnitude * 3.6f;
        rpm = veloKMH * racioMudancas[mudancaAtual] *15f;
        
        //MUDANCAS

        if(rpm > maxRPM)
        {
            mudancaAtual++;
            if(mudancaAtual == racioMudancas.Length)
            {
                mudancaAtual--;
            }
        }

        if (rpm < minRPM)
        {
            mudancaAtual--;
            if (mudancaAtual < 0)
            {
                mudancaAtual = 0;
            }
        }

        //FORCAS

        if(acc < -0.5f)
        {
            rb.AddForce(-transform.forward * forcaTravagem);
            acc = 0;
        }
        //Muda a força conforme a marcha passa. Por exemplo MaxTorque tem o valor 5000 divide pela marcha atual e dar a força que o carro pode ter, quanto maior a marcha menos força tem
        forcaFinal = transform.forward * (maxTorque / (mudancaAtual+1) + maxTorque/3f)  * acc ;
        rb.AddForce(forcaFinal);

        //SOM
        audioCarro.pitch = rpm / somPitch;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20,20,128,32),rpm + "RPM");
        GUI.Label(new Rect(20,40,128,32), (mudancaAtual+1).ToString());
        GUI.Label(new Rect(20,60,128,32),veloKMH + "KM/H");
        GUI.Label(new Rect(20,80,128,32),forcaFinal.magnitude.ToString());
        
    }
}
