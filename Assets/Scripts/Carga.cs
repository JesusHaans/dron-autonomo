using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Componente auxiliar que modela el comportamiento de una bateria interna
// Dicha batería se descarga constantemente a menos que se utilize un método para recargar
public class Carga : MonoBehaviour
{
    public GameObject carga1; //Libro 1 en cargar
    public GameObject carga2; //Libro 1 en cargar
    public GameObject carga3; //Libro 1 en cargar
    private int carga;

    void Start(){
        carga1 = GameObject.Find("Carga 1").gameObject;
        carga2 = GameObject.Find("Carga 2").gameObject;
        carga3 = GameObject.Find("Carga 3").gameObject;
        carga1.SetActive(false);
        carga2.SetActive(false);
        carga3.SetActive(false);
        carga = 0;
    }

    // ========================================
    // Métodos públicos que podrán ser utilizados por otros componentes (scripts):
    public void Cargar(){
        if(carga == 0){
           carga1.SetActive(true); 
           carga++;
        }else{
        if(carga == 1){
           carga2.SetActive(true); 
           carga++;
        }else{
        if(carga == 2){
           carga3.SetActive(true); 
           carga++;
        }
        }
        }
    }

    public void Descargar(){
        carga1.SetActive(false);
        carga2.SetActive(false);
        carga3.SetActive(false);
        carga = 0;
    }

    public int NivelDeCarga(){
        return carga;
    }

}
