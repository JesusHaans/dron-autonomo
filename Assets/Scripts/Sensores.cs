using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sensores : MonoBehaviour{

    private Radar radar; // Componente auxiliar (script) para utilizar radar.
    private Carga carga;//Componente auxiliar (script) para la carga de libros.
    private Bateria bateria;//Componente auxiliar (script) para la bateria
    private Actuadores actuador; // Componente adicional (script) para obtener información de los actuadores
    private GameObject libro; // Auxiliar para guardar referencia al objeto


    public Vector3 posicion;//auxiliar para la posicion del dron
    private bool tocandoLibro; // Bandera auxiliar para mantener el estado en caso de tocar un libro
    private bool cercaLibro; // Bandera auxiliar para mantener el estado en caso de estar cerca de un libro

    // Asignaciones de componentes
    void Start(){
        radar = GameObject.Find("Radar").gameObject.GetComponent<Radar>();
        bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
        carga = GameObject.Find("Carga").gameObject.GetComponent<Carga>();
        actuador = GetComponent<Actuadores>();
        posicion = GameObject.Find("Dron").transform.position;

    }

    void Update(){
      //cercaPared = radar.CercaDePared();
      //cercaBasura = radar.CercaDeBasura();
      //frentePared = rayo.FrenteAPared();
    }



    public void ActualizarPosicion(){
       posicion = GameObject.Find("Dron").transform.position;
    }


    // ========================================
    // Los siguientes métodos permiten la detección de eventos de colisión
    // que junto con etiquetas de los objetos permiten identificar los elementos
    // La mayoría de los métodos es para asignar banderas/variables de estado.

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            tocandoLibro = true;
            libro = other.gameObject;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            tocandoLibro = true;
            libro = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            tocandoLibro = false;
        }
    }

    // ========================================
    // Los siguientes métodos definidos son públicos, la intención
    // es que serán usados por otro componente (Controlador)


    public bool TocandoLibro(){
        return tocandoLibro;
    }

    public bool CercaDeLibro(){
        return radar.CercaDeLibro();
    }

    public float Bateria(){
        return bateria.NivelDeBateria();
    }

    // Algunos otros métodos auxiliares que pueden ser de apoyo

    public GameObject GetLibro(){
        return radar.LibroEnRadar();
    }

    public Vector3 Ubicacion(){
        return transform.position;
    }

    public void SetTocandoLibro(bool value){
        tocandoLibro = value;
    }

    public void SetCercaDeLibro(bool value){
        radar.setCercaDeLibro(value);
    }

    public int CargaDeLibros(){
        return carga.NivelDeCarga();
    }
}
