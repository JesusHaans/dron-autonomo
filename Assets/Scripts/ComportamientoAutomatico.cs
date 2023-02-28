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
	int contador;

	void Start(){
		sensor = GetComponent<Sensores>();
		actuador = GetComponent<Actuadores>();
		baseDeCarga = GameObject.Find("BaseDeCarga").transform.position;
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
        	actuador.avanzar(mesas[0][0], mesas[0][2]);
        	actuador.Detener();
        }else{
        	if(dist0 == 0 && contador == 0) contador++;
        }
        float dist1 = Vector3.Distance(mesas[1], sensor.posicion) - sensor.posicion[1] + mesas[1][1];
        //print("Distance to other: " + dist);
        if(dist1 != 0 && contador == 1){
        	actuador.avanzar(mesas[1][0], mesas[1][2]);
        	actuador.Detener();
        }else{
        	if(dist1 == 0 && contador == 1) contador++;
        }
        float dist2 = Vector3.Distance(mesas[2], sensor.posicion) - sensor.posicion[1] + mesas[2][1];
        //print("Distance to other: " + dist);
        if(dist2 != 0 && contador == 2){
        	actuador.avanzar(mesas[2][0], mesas[2][2]);
        	actuador.Detener();
        }else{
        	if(dist2 == 0 && contador == 2) contador++;
        }
        float dist3 = Vector3.Distance(mesas[3], sensor.posicion) - sensor.posicion[1] + mesas[3][1];
        //print("Distance to other: " + dist);
        if(dist0 != 0 && contador == 3){
        	actuador.avanzar(mesas[3][0], mesas[3][2]);
        	actuador.Detener();
        }else{
        	if(dist0 == 0 && contador == 3) contador++;
        }



        // A continuación se muestran ejemplos de uso de actuadores y sensores
        // para ser utilizados de manera manual (por una persona):

        if(Input.GetKey(KeyCode.I))
            actuador.Ascender();
        if(Input.GetKey(KeyCode.K))
            actuador.Descender();
        /*if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
            actuador.Flotar();*/

        if(Input.GetAxis("Vertical") > 0)
            actuador.Adelante();
        if(Input.GetAxis("Vertical") < 0)
            actuador.Atras();

        if(Input.GetKey(KeyCode.J))
            actuador.GirarIzquierda();
        if(Input.GetKey(KeyCode.L))
            actuador.GirarDerecha();

        if(Input.GetAxis("Horizontal") > 0)
            actuador.Derecha();
        if(Input.GetAxis("Horizontal") < 0)
            actuador.Izquierda();


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

