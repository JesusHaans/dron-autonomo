using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuadores : MonoBehaviour
{
    private Rigidbody rb; // Componente para simular acciones físicas realistas
    private Bateria bateria; // Componente adicional (script) que representa la batería
    private Sensores sensor; // Componente adicional (script) para obtener información de los sensores

    private float upForce; // Indica la fuerza de elevación del dron
    private float movementForwardSpeed = 100.0f; // Escalar para indicar fuerza de movimiento frontal
    private float wantedYRotation; // Auxiliar para el cálculo de rotación
    private float currentYRotation; // Auxiliar para el cálculo de rotación
    private float rotateAmountByKeys = 2.5f; // Auxiliar para el cálculo de rotación
    private float rotationYVelocity; // Escalar (calculado) para indicar velocidad de rotación
    private float sideMovementAmount = 250.0f; // Escalar para indicar velocidad de movimiento lateral

    // Asignaciones de componentes
    void Start(){
        rb = GetComponent<Rigidbody>();
        sensor = GetComponent<Sensores>();
        bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
    }

    // ========================================
    // A partir de aqui, todos los métodos definidos son públicos, la intención
    // es que serán usados por otro componente (Controlador)

    public void Ascender(){
        upForce = 190;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Descender(){
        upForce = 10;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Flotar(){
        upForce = 98.1f;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Adelante(){
        rb.AddRelativeForce(Vector3.forward * movementForwardSpeed);
    }

    public void Atras(){
        rb.AddRelativeForce(Vector3.back * movementForwardSpeed);
    }

    public void GirarDerecha(){
        transform.Rotate(Vector3.up, 1.0f);
    }

    public void GirarIzquierda(){
        transform.Rotate(Vector3.up, -1.0f);
    }

    public void Derecha(){
        rb.AddRelativeForce(Vector3.right * sideMovementAmount);
    }

    public void Izquierda(){
        rb.AddRelativeForce(Vector3.left * sideMovementAmount);
    }

    public void Detener(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void Limpiar(GameObject basura){
        basura.SetActive(false);
        sensor.SetTocandoBasura(false);
        sensor.SetCercaDeBasura(false);
    }

    public void CargarBateria(){
        bateria.Cargar();
    }
}
