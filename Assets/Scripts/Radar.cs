using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Componente auxiliar que utiliza un Collider de pirámide a manera de radar
// para comprobar colisiones con otros elementos.
// Las comprobaciones y métodos son análogos al componente (script) de Sensores.
public class Radar : MonoBehaviour{

    private bool cercaDeLibro;
    //private bool cercaDePared;
    private GameObject libro; // Auxiliar para guardar referencia al objeto

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = true;
            libro = other.gameObject;
        }/*
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = true;
        }*/
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = true;
            libro = other.gameObject;
        }
        /*
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = true;
        }*/
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = false;
            libro = null;
        }
        /*
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = false;
        }*/
    }

    public bool CercaDeLibro(){
        return cercaDeLibro;
    }
/*
    public bool CercaDePared(){
        return cercaDePared;
    }*/

    public GameObject LibroEnRadar(){
        return libro;
    }

    public void setCercaDeLibro(bool value){
        cercaDeLibro = value;
    }
}
