using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour {

    public bool rot;
    private Bateria bateria;
    public Sensores sensor;

    //Hace rota el GameObject al que est� asociado en
    //un rango 60 grados por frame.
    void Start() {

        //bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
    }
    
    
    void Update() {
        if(sensor.Bateria() <= 0){
            rot = false;
        }else{
            rot = true;
        }

        if(rot){
            this.transform.Rotate(new Vector3(0.0f, 60.0f, 0.0f));
        }
        else{
            this.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

}



/*
            NOTAS PARA AVANZAR CON EL DRON


            PARA APARECER OBJETOS EN EL ESCENARIOUSAREMOS.

            instantiate(objeto a aparecer(game object), cordenada(vector), rotacion(Quaternion.identity para usar la rotacion original del objeto padre))


            mathf.infinity

            IEnumerator espera(){
                yield return new WaitForSeconds( <Tiempo que vamos esperar> );para poder hacer una maquina de estados
                Cambio de estado
            }


            corrutinas con un public void y el numero de corrutina 
            paramos primero todas las corrutinas y luego hacemos la que queremos

*/