using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public Vector3 baseDeCarga;
	int grados = 0;
	bool girando = false;
	bool dir = true; 
	private float movementSpeed = 5f;
	public Vector3[] mesas = new Vector3[4];
	public Vector3 zonaDeDesinfeccion;
	int contador;

	void Start(){
		sensor = GetComponent<Sensores>();
		actuador = GetComponent<Actuadores>();
		baseDeCarga = GameObject.Find("BaseDeCarga").transform.position;
		zonaDeDesinfeccion = GameObject.Find("zona desinfección").transform.position;
		mesas[0] = GameObject.Find("mesa").transform.position;
		mesas[1] = GameObject.Find("mesa (1)").transform.position;
		mesas[2] = GameObject.Find("mesa (2)").transform.position;
		mesas[3] = GameObject.Find("mesa (3)").transform.position;
		contador = 0;
		//uBase = GameObject.Find("Base").transform;
		//baseCarga = this.transform;
	}

	void FixedUpdate () {
		/*
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
		}*/

		//actuador.Flotar();
		//actuador.avanzarCasilla();

        //update the position
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        //output to log the position change
        //Debug.Log(transform.position);
        //Debug.Log("Quedamos en la casilla (" + sensor.posicionx() + "," +sensor.posicionz() + ")");
        float a = 120;
        float b = 120;
        
        float dist0 = Vector3.Distance(mesas[0], sensor.posicion) - sensor.posicion[1] + mesas[0][1];
        //print("Distance to other: " + dist);
        if(dist0 != 0 && contador == 0){
			//Debug.Log("llegue aqui");
			actuador.avanzar(mesas[0][0], mesas[0][2]);
        	actuador.Detener();
        }else{
        	if(dist0 == 0 && contador == 0) {
        		contador++;
        		if(sensor.CercaDeLibro()) Debug.Log("Encontre 1 libro");
        	}
        }
        float dist1 = Vector3.Distance(mesas[1], sensor.posicion) - sensor.posicion[1] + mesas[1][1];
        //print("Distance to other: " + dist);
        if(dist1 != 0 && contador == 1){
        	actuador.avanzar(mesas[1][0], mesas[1][2]);
        	actuador.Detener();
        }else{
        	if(dist1 == 0 && contador == 1){
        	 contador++;
        	 if(sensor.CercaDeLibro()) Debug.Log("Encontre 2 libro");
        	}
        }
        float dist2 = Vector3.Distance(mesas[2], sensor.posicion) - sensor.posicion[1] + mesas[2][1];
        //print("Distance to other: " + dist);
        if(dist2 != 0 && contador == 2){
        	actuador.avanzar(mesas[2][0], mesas[2][2]);
        	actuador.Detener();
        }else{
        	if(dist2 == 0 && contador == 2){
        	 contador++;
        	 if(sensor.CercaDeLibro()) Debug.Log("Encontre 3 libro");
        	}
        }
        float dist3 = Vector3.Distance(mesas[3], sensor.posicion) - sensor.posicion[1] + mesas[3][1];
        //print("Distance to other: " + dist);
        if(dist3 != 0 && contador == 3){
        	actuador.avanzar(mesas[3][0], mesas[3][2]);
        	actuador.Detener();
        }else{
        	if(dist3 == 0 && contador == 3){
        	 contador++;
        	 if(sensor.CercaDeLibro()) Debug.Log("Encontre 4 libro");
        	}
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

