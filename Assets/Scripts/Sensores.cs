using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sensores : MonoBehaviour{

    private Radar radar; // Componente auxiliar (script) para utilizar radar esférico
    //private Rayo rayo; // Componente auxiliar (script) para utilizar rayo lineal
    private Bateria bateria; // Componente adicional (script) que representa la batería
    private Actuadores actuador; // Componente adicional (script) para obtener información de los ac
    //private GameObject basura; // Auxiliar para guardar referencia al objeto
    //public GameObject estacionDeCarga;
    public double x;
    public double z;
    public Vector3 posicion;
    public int carga;
/*
    private bool tocandoPared; // Bandera auxiliar para mantener el estado en caso de tocar pared
    private bool cercaPared; // Bandera auxiliar para mantener el estado en caso de estar cerca de una pared
    private bool frentePared; // Bandera auxiliar para retomar el estado en caso de estar frente a una pared
    private bool tocandoBasura; // Bandera auxiliar para mantener el estado en caso de tocar basura
    private bool cercaBasura; // Bandera auxiliar para mantener el estado en caso de estar cerca de una basura
*/
    // Asignaciones de componentes
    void Start(){
        radar = GameObject.Find("Radar").gameObject.GetComponent<Radar>();
        //rayo = GameObject.Find("Rayo").gameObject.GetComponent<Rayo>();
        bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
        actuador = GetComponent<Actuadores>();
        x = Math.Floor(Input.GetAxis("Horizontal"));
        z = Math.Floor(Input.GetAxis("Vertical"));

        posicion = GameObject.Find("Dron").transform.position;
        carga = 0;

    }

    void Update(){
      //cercaPared = radar.CercaDePared();
      //cercaBasura = radar.CercaDeBasura();
      //frentePared = rayo.FrenteAPared();
    }

    public int posicionx(){
        posicion = GameObject.Find("Dron").transform.position;
        x = Math.Floor(posicion[0]/10);
        return (int) x; 

    }

    public int posicionz(){
        posicion = GameObject.Find("Dron").transform.position;
        this.z = Math.Floor(posicion[2]/10);
        return (int) z;
    }

    public void ActualizarPosicion(){
        posicion = GameObject.Find("Dron").transform.position;
    }


    // ========================================
    // Los siguientes métodos permiten la detección de eventos de colisión
    // que junto con etiquetas de los objetos permiten identificar los elementos
    // La mayoría de los métodos es para asignar banderas/variables de estado.
/*
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Pared")){
            tocandoPared = true;
        }
    }

    void OnCollisionStay(Collision other){
        if(other.gameObject.CompareTag("Pared")){
            tocandoPared = true;
        }
        if(other.gameObject.CompareTag("BaseDeCarga")){
            actuador.CargarBateria();
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Pared")){
            tocandoPared = false;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            tocandoBasura = true;
            basura = other.gameObject;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            tocandoBasura = true;
            basura = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            tocandoBasura = false;
        }
    }

    // ========================================
    // Los siguientes métodos definidos son públicos, la intención
    // es que serán usados por otro componente (Controlador)

    public bool TocandoPared(){
        return tocandoPared;
    }

    public bool CercaDePared(){
        return radar.CercaDePared();
    }

    public bool FrenteAPared(){
        return rayo.FrenteAPared();
    }

    public bool TocandoBasura(){
        return tocandoBasura;
    }

    public bool CercaDeBasura(){
        return radar.CercaDeBasura();
    }

    public float Bateria(){
        return bateria.NivelDeBateria();
    }

    // Algunos otros métodos auxiliares que pueden ser de apoyo

    public GameObject GetBasura(){
        return basura;
    }

    public Vector3 Ubicacion(){
        return transform.position;
    }

    public void SetTocandoBasura(bool value){
        tocandoBasura = value;
    }

    public void SetCercaDeBasura(bool value){
        radar.setCercaDeBasura(value);
    }*/
}
