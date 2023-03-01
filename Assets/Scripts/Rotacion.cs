using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour {

    public bool rot;
    private Bateria bateria;

    //Hace rota el GameObject al que est� asociado en
    //un rango 60 grados por frame.
    void Start() {
        bateria = GameObject.Find("Bateria").gameObject.GetComponent<Bateria>();
    }
    
    
    void Update() {
        if(bateria.NivelDeBateria() <= 0){
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
