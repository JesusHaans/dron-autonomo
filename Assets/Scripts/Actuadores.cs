using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuadores : MonoBehaviour
{
    private Rigidbody rb; // Componente para simular acciones físicas realistas
    private Bateria bateria; // Componente adicional (script) que representa la batería
    private Carga carga;//Componente adicional (script) que representa la carga de libros
    private Sensores sensor; // Componente adicional (script) para obtener información de los sensores

    private float upForce; // Indica la fuerza de elevación del dron
    private float movementForwardSpeed = 10.0f; // Escalar para indicar fuerza de movimiento frontal
    private float wantedYRotation; // Auxiliar para el cálculo de rotación
    private float currentYRotation; // Auxiliar para el cálculo de rotación
    private float rotationYVelocity; // Escalar (calculado) para indicar velocidad de rotación
    private float sideMovementAmount = 25.0f; // Escalar para indicar velocidad de movimiento lateral

    // Asignaciones de componentes
    void Start(){
        rb = GetComponent<Rigidbody>();
        sensor = GetComponent<Sensores>();
        bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
        carga = GameObject.Find("Carga").gameObject.GetComponent<Carga>();
    }

    // ========================================
    // A partir de aqui, todos los métodos definidos son públicos, la intención
    // es que serán usados por otro componente (Controlador)
    //METODOS DE LABORATORIO
    public void Ascender(){
        upForce = 190;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Descender(){
        upForce = 0;
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

    //MÉTODOS ADICIONADOS

    /*Carga la batería del dron*/
    public void CargarBateria(){
        bateria.Cargar();
    }

    /*Mueve al dron de su posición actual a la posición dada*/
    public void avanzar(float x , float z){
        sensor.ActualizarPosicion();//Primero actualizamos la posición del dron
        Vector3 objetivo = new Vector3(x, sensor.posicion[1], z);//este es el punto donde queremos llegar
        transform.position = Vector3.MoveTowards(sensor.posicion, objetivo, 30.0f * Time.deltaTime); //Nos movemos al punto objetivo
        sensor.ActualizarPosicion();//Como nos movimos, actualizamos nuestra posición.
    }

    /*Desciende el dron*/
    public void Descender(Vector3 obj){
        Vector3 objetivo= obj;//Aquí ponemos el punto donde queremos poner el dron
        objetivo[1] = 2*objetivo[1];//Aquí indicamos en el punto que queremos que baje
        sensor.ActualizarPosicion();//Donde esta el dron actualmente?
        transform.position = Vector3.MoveTowards(sensor.posicion, objetivo, 30.0f * Time.deltaTime); //Bajamos al punto objetivo
        sensor.ActualizarPosicion();//Como nos movimos, actualizamos nuestra posición.
    }

    /* Para ascender el dron a la altura predilecta */
    public void Ascender(Vector3 obj){
        Vector3 objetivo= obj;//Aquí ponemos el punto donde queremos poner el dron
        objetivo[1] = 26.0f;//Aquí indicamos en el punto que queremos que suba
        sensor.ActualizarPosicion();//Donde esta el dron actualmente?
        transform.position = Vector3.MoveTowards(sensor.posicion, objetivo, 30.0f * Time.deltaTime); //Subumos al punto objetivo
        sensor.ActualizarPosicion();//Como nos movimos, actualizamos nuestra posición.
    }

    /*Método para recoger un libro y ponerlo en nuestra carga de libros*/
    public void RecogerLibro(GameObject libro){ 
        if(libro.activeSelf){//Si está activo
            libro.SetActive(false);//Lo inactivamos
            carga.Cargar();//Lo cargamos
        }

    }

    /*Método para descargar los libros al llegar a la zona de desinfección*/
    public void DescargarLibros(){
        carga.Descargar();
    }

}
