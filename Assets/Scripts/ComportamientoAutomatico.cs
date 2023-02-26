using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public Vector3 baseDeCarga = Vector3.zero;
	public Transform uBase;
	public Transform baseCarga;
	int grados = 0;
	bool girando = false;
	bool dir = true; 


	void Start(){
		sensor = GetComponent<Sensores>();
		actuador = GetComponent<Actuadores>();
		uBase = GameObject.Find("Base").transform;
		baseCarga = this.transform;
	}

	void FixedUpdate () {
		if(sensor.Bateria() <= 0) {
			return;
		}

		if(girando){
			Rotar();
		}

		if (sensor.FrenteAPared()) {
			girando = true;
			actuador.Flotar();
			actuador.Detener();
			Rotar();
		} else {
			actuador.Flotar();
			actuador.Adelante();
		}

	}

	void Rotar(){
		grados++;
        if(grados <= 90){
			actuador.Detener();
			if(dir){
				actuador.GirarDerecha();
			}else{
				actuador.GirarIzquierda();
			}
		}else{
			grados = 0;
			girando = false;
		}
    }
}

