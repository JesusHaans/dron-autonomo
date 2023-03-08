using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public Vector3 baseDeCarga;
	private bool cicloTerminado;
	int grados = 0;
	bool girando = false;
	bool dir = true; 
	private float movementSpeed = 5f;
	public Vector3[] mesas = new Vector3[4];
	public Vector3 zonaDeDesinfeccion;
	int contador;
	int recuerdo;
	bool cargar;
	int descendiendo;

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
		cicloTerminado = false;
		cargar = false;
		descendiendo = 0;
		//uBase = GameObject.Find("Base").transform;
		//baseCarga = this.transform;
	}

	void FixedUpdate () {
		/*
		if(sensor.Bateria() <= 20.0f){
			recuerdo=contador;
			contador=10;
		}
		
		if(contador == 10){
			float dist10 = Vector3.Distance(baseDeCarga, sensor.posicion) - sensor.posicion[1] + baseDeCarga[1];
			Debug.Log("Distancia a base de carga: " + dist10);
			if(dist10 != 0 && contador == 10){
				actuador.avanzar(baseDeCarga[0], baseDeCarga[2]);
				actuador.Detener();
			}
			if(dist10 == 0 && contador == 10 && sensor.Bateria()<= 120.0f){
				actuador.Descender();
				contador=recuerdo;
				

			}
		}*/
		if(!cargar){
			if(sensor.Bateria() <= 20.0f){
				cargar = true;
			}else{
				if(sensor.CargaDeLibros() < 3 && contador < 4){

			        float dist0 = Vector3.Distance(mesas[0], sensor.posicion) - sensor.posicion[1] + mesas[0][1];
			        //print("Distance to other: " + dist);
			        if(dist0 != 0 && contador == 0){
						//Debug.Log("llegue aqui");
						actuador.avanzar(mesas[0][0], mesas[0][2]);
			        	actuador.Detener();
			        }else{
			        	if(dist0 == 0 && contador == 0) {
			        		contador++;
			        		if(sensor.CercaDeLibro()){
			        		 Debug.Log("Encontre " + sensor.GetLibro().name);
			        		 actuador.RecogerLibro(sensor.GetLibro());
			        		}
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
			        	 if(sensor.CercaDeLibro()){
			        	  Debug.Log("Encontre  " + sensor.GetLibro().name);
			        	  actuador.RecogerLibro(sensor.GetLibro());
			        	 }
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
			        	 if(sensor.CercaDeLibro()){
			        	  Debug.Log("Encontre  " + sensor.GetLibro().name);
			        	  actuador.RecogerLibro(sensor.GetLibro());
			        	 }
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
			        	 if(sensor.CercaDeLibro()){
			        	  Debug.Log("Encontre " + sensor.GetLibro().name);
			        	  actuador.RecogerLibro(sensor.GetLibro());
			        	 }
			        	}
			        	actuador.Flotar();
			        }
				}else{
					float distanciaZona = Vector3.Distance(zonaDeDesinfeccion, sensor.posicion) - sensor.posicion[1] + zonaDeDesinfeccion[1];
					if(distanciaZona != 0){
						actuador.avanzar(zonaDeDesinfeccion[0],zonaDeDesinfeccion[2]);
						actuador.Detener();
					}else{
						actuador.Flotar();
						actuador.DescargarLibros();
						if(contador == 4) contador = 0;
						actuador.Flotar();
					}
				
				}
			}
		}else{
			float distBase = Vector3.Distance(baseDeCarga, sensor.posicion) - sensor.posicion[1] + baseDeCarga[1];
			//Debug.Log("Distancia a base de carga: " + distBase);
			if(distBase != 0 && descendiendo == 0){
				actuador.avanzar(baseDeCarga[0], baseDeCarga[2]);
				actuador.Detener();
			}
			if(distBase == 0){
				descendiendo = 1;	
			}
			if(descendiendo == 1){
				float distBase2 = Vector3.Distance(baseDeCarga, sensor.posicion) - baseDeCarga[1];
				if(distBase2 != 0){
					actuador.Descender(baseDeCarga);
					actuador.Detener();
				}
				if(distBase2 == 0){
					descendiendo = 2;//Cambiamos a cargando
				}
			}
			if(descendiendo == 2){
				//Debug.Log("Batería " + sensor.Bateria());
				if(sensor.Bateria() >= 120.0f){
					descendiendo = 3;//Terminamos de cargar
					Debug.Log("Acabamos de cargar");
				}else{
					actuador.Detener();
					actuador.CargarBateria();
					actuador.Detener();
				}

			}
			if(descendiendo == 3){
				Vector3 flotando = new Vector3(baseDeCarga[0], 26.0f, baseDeCarga[2]);
				float distBase3 = Vector3.Distance(flotando, sensor.posicion)-2;
				Debug.Log("Subimos? " + distBase3);
				if(distBase3 >= 0){
					actuador.Ascender(flotando);
					actuador.Detener();
				}
				if(distBase3 < 0){
					descendiendo = 0;//Cambiamos a cargando
					cargar = false;
				}
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

