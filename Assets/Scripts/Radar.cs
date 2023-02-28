using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Componente auxiliar que utiliza un Collider esférico a manera de radar
// para comprobar colisiones con otros elementos.
// Las comprobaciones y métodos son análogos al componente (script) de Sensores.
public class Radar : MonoBehaviour{

    private bool cercaDeLibro;
    private bool cercaDePared;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = true;
        }
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = true;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = true;
        }
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Libro")){
            cercaDeLibro = false;
        }
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = false;
        }
    }

    public bool CercaDeLibro(){
        return cercaDeLibro;
    }

    public bool CercaDePared(){
        return cercaDePared;
    }

    public void setCercaDeLibro(bool value){
        cercaDeLibro = value;
    }
}
