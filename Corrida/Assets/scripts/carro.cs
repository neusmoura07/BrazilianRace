using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{

    public WheelCollider[] guiar;
    
    public float gui = 0f;
    public float acc = 0f;

    Rigidbody rb;

    public AnimationCurve curvaRoda;
    public AudioClip somcarro;
    public AudioSource audioCarro;
    public float maxTorque;

    public float forcaTravagem;

    public float veloKMH;
    public float rpm;

    public float[] racioMudancas;
    int mudancaAtual = 0;

    public float maxRPM;
    public float minRPM;
    public float somPitch;

    public Vector3 forcaFinal;

    public GameObject centroMassa;

    public float instabilidadeTravar;

    public int voltas = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = centroMassa.transform.localPosition;
        audioCarro.clip = somcarro;


    }

    // Update is called once per frame
    
    public void SomarVolta()
    {
        voltas++;
        Debug.Log("DEMOS UMA VOLTA! -" + voltas.ToString());
    }

    void FixedUpdate()
    {
        //GUIAR
        //Entrar na lista e todos elementos vão fazer qualquer coisa, coloca um angulo na roda 
        for (int i = 0; i< guiar.Length; i++){
            guiar[i].steerAngle = gui * curvaRoda.Evaluate(veloKMH);
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

            rb.AddTorque((transform.up * instabilidadeTravar * veloKMH / 45f ) * gui);

            acc = 0;
        }
        //Muda a força conforme a marcha passa. Por exemplo MaxTorque tem o valor 5000 divide pela marcha atual e dar a força que o carro pode ter, quanto maior a marcha menos força tem
        forcaFinal = transform.forward * (maxTorque / (mudancaAtual + 1) + maxTorque/1.25f)  * acc ;
        rb.AddForce(forcaFinal);

        //SOM
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20,20,128,32),rpm + "RPM");
        GUI.Label(new Rect(20,40,128,32), (mudancaAtual+1).ToString());
        GUI.Label(new Rect(20,60,128,32),veloKMH + "KM/H");
        GUI.Label(new Rect(20,80,128,32),forcaFinal.magnitude.ToString());
    
    }
}
