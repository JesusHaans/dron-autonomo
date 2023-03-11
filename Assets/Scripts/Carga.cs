using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Componente auxiliar que modela el comportamiento de la carga de libros del dron
// El dron solo puede cargar 3 libros a la vez
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

    /*Método que usamos para cargar un libro*/
    public void Cargar(){
        if(carga == 0){//Si no traemos ningún libro
           carga1.SetActive(true); //Cargamos el primero
           carga++;//Indicamos que ya llevamos un libro
        }else{
        if(carga == 1){//Si ya traemos un libro
           carga2.SetActive(true); //Cargamos el segundo libro
           carga++;//Indicamos que ya llevamos dos libros
        }else{
        if(carga == 2){//Si ya traemos dos libros
           carga3.SetActive(true); //Cargamos el tercer libro
           carga++;//Indicamos que ya llevamos tres libros
        }
        }
        }
    }

    /*Método para descargar los libros que llevamos*/
    public void Descargar(){
        carga1.SetActive(false);
        carga2.SetActive(false);
        carga3.SetActive(false);
        carga = 0;
    }

    /*Método para saaber cuántos libros lleva el dron*/
    public int NivelDeCarga(){
        return carga;
    }

}
