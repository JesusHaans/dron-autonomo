using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;

	//Esta es la información de nuestro entorno
	public Vector3 baseDeCarga;//donde está nuestra base de carga
	public Vector3 zonaDeDesinfeccion;//donde esta la zona de desinfección donde dejamos libros
	public Vector3[] mesas = new Vector3[4];//Esta es la posición de las mesas donde recogeremos libros

	//Auxiliares
	int contador;//esto nos dice en qué parte del recorrido de mesas estamos
	bool cargar;//Nos ayuda a saber si el dron se dirige a su base de carga
	int descendiendo;//Nos ayuda a saber si el dron está descendiendo a su base de caga
	int libros1;//Nos ayuda a saber si el usuario quiere poner un libro en mesa 1
	int libros2;//Nos ayuda a saber si el usuario quiere poner un libro en mesa 2
	int libros3;//Nos ayuda a saber si el usuario quiere poner un libro en mesa 3
	int libros4;//Nos ayuda a saber si el usuario quiere poner un libro en mesa 4

	void Start(){
		sensor = GetComponent<Sensores>();
		actuador = GetComponent<Actuadores>();

		//Preparando la información base del entorno
		baseDeCarga = GameObject.Find("BaseDeCarga").transform.position;
		zonaDeDesinfeccion = GameObject.Find("zona desinfección").transform.position;
		mesas[0] = GameObject.Find("mesa").transform.position;
		mesas[1] = GameObject.Find("mesa (1)").transform.position;
		mesas[2] = GameObject.Find("mesa (2)").transform.position;
		mesas[3] = GameObject.Find("mesa (3)").transform.position;
		
		//Iniciamos auxiliares
		contador = 0;
		cargar = false;
		descendiendo = 0;
		libros1 = 0;
		libros2 = 0;
		libros3 = 0;
		libros4 = 0;
	}

	void FixedUpdate () {

		/* SECCIÓN 1 AGREGAR LIBROS
			Lo primero que haremos es preguntar si el usuario presiona una tecla para agregar un libro a una mesa.
			Usamos las teclas:
			Q : Mesa 0
			W : Mesa 1
			A : Mesa 2
			S : Mesa 3
		*/
		if(Input.GetKey(KeyCode.Q)){
			if(libros1 == 0){//Si se acaba de presionar el botón
				Libros.NuevoLibro(GameObject.Find("mesa"));//Agregamos un libro a la mesa.
			}
			libros1++;
			
		}else{
			libros1 = 0;//Si dejamos de presionar reiniciamos nuestro indicador
		}
		if(Input.GetKey(KeyCode.W)){
			if(libros2 == 0){//Si se acaba de presionar el botón
				Libros.NuevoLibro(GameObject.Find("mesa (1)"));//Agregamos un libro a la mesa.
			}
			libros2++;
		}else{
			libros2 = 0;//Si dejamos de presionar reiniciamos nuestro indicador
		}
		if(Input.GetKey(KeyCode.A)){
			if(libros3 == 0){//Si se acaba de presionar el botón
				Libros.NuevoLibro(GameObject.Find("mesa (2)"));//Agregamos un libro a la mesa.
			}
			libros3++;
		}else{
			libros3 = 0;//Si dejamos de presionar reiniciamos nuestro indicador
		}
		if(Input.GetKey(KeyCode.S)){
			if(libros4 == 0){//Si se acaba de presionar el botón
				Libros.NuevoLibro(GameObject.Find("mesa (3)"));//Agregamos un libro a la mesa.
			}
			libros4++;
		}else{
			libros4 = 0;//Si dejamos de presionar reiniciamos nuestro indicador
		}

		//SECCIÓN 2. COMPORTAMIENTO
		if(!cargar){//Si aún tenemos pila
			//Lo primero que haremos será verificar que efectivamente tenemos batería
			if(sensor.Bateria() <= 20.0f){//Si ya no tenemos mucha pila, indicamos que vamos a ir a la base de carga
				cargar = true;
			}else{//Si aún tenemos pila suficiente.

				//Lo siguiente es que si tenemos pila, para continuar debemos poder cargar libros todavía
				if(sensor.CargaDeLibros() < 3 && contador < 4){//Si aún podemos cargar libros y aún no terminamos el recorrido
			        
			        //RECORRIDO HACIA MESA 0
			        float dist0 = Vector3.Distance(mesas[0], sensor.posicion) - sensor.posicion[1] + mesas[0][1];//Distancia para ver que tan cerca de la mesa estamos
			        if(dist0 != 0 && contador == 0){//Si aún no llegamos al punto y aún tenemos que llegar
						actuador.avanzar(mesas[0][0], mesas[0][2]);//Seguimos nuestro camino hacia la mesa
			        	actuador.Detener();
			        }else{
			        	if(dist0 == 0 && contador == 0) { //Si llegamos a la mesa y aún es nuestro objetivo llegar ahí
			        		contador++;//indicamos que lo que sigue es otra mesa
			        		if(sensor.CercaDeLibro()){//Ya que llegamos a la mesa, ¿Hay algún libro?
			        		 actuador.RecogerLibro(sensor.GetLibro());//Si encontramos uno, lo cargamos
			        		}
			        	}
			        }

			        //RECORRIDO HACIA MESA 1
			        float dist1 = Vector3.Distance(mesas[1], sensor.posicion) - sensor.posicion[1] + mesas[1][1];//Distancia para ver que tan cerca de la mesa estamos
			        if(dist1 != 0 && contador == 1){//Si aún no llegamos al punto y aún tenemos que llegar
			        	actuador.avanzar(mesas[1][0], mesas[1][2]);//Seguimos nuestro camino hacia la mesa
			        	actuador.Detener();
			        }else{
			        	if(dist1 == 0 && contador == 1){//Si llegamos a la mesa y aún es nuestro objetivo llegar ahí
			        	 contador++;//indicamos que lo que sigue es otra mesa
			        	 if(sensor.CercaDeLibro()){//Ya que llegamos a la mesa, ¿Hay algún libro?
			        	  actuador.RecogerLibro(sensor.GetLibro());//Si encontramos uno, lo cargamos
			        	 }
			        	}
			        }

			        //RECORRIDO HACIA MESA 2
			        float dist2 = Vector3.Distance(mesas[2], sensor.posicion) - sensor.posicion[1] + mesas[2][1];//Distancia para ver que tan cerca de la mesa estamos
			        if(dist2 != 0 && contador == 2){//Si aún no llegamos al punto y aún tenemos que llegar
			        	actuador.avanzar(mesas[2][0], mesas[2][2]);//Seguimos nuestro camino hacia la mesa
			        	actuador.Detener();
			        }else{
			        	if(dist2 == 0 && contador == 2){//Si llegamos a la mesa y aún es nuestro objetivo llegar ahí
			        	 contador++;//indicamos que lo que sigue es otra mesa
			        	 if(sensor.CercaDeLibro()){//Ya que llegamos a la mesa, ¿Hay algún libro?
			        	  actuador.RecogerLibro(sensor.GetLibro());//Si encontramos uno, lo cargamos
			        	 }
			        	}
			        }

			        //RECORRIDO HACIA MESA 3
			        float dist3 = Vector3.Distance(mesas[3], sensor.posicion) - sensor.posicion[1] + mesas[3][1];//Distancia para ver que tan cerca de la mesa estamos
			        if(dist3 != 0 && contador == 3){//Si aún no llegamos al punto y aún tenemos que llegar
			        	actuador.avanzar(mesas[3][0], mesas[3][2]);//Seguimos nuestro camino hacia la mesa
			        	actuador.Detener();
			        }else{
			        	if(dist3 == 0 && contador == 3){//Si llegamos a la mesa y aún es nuestro objetivo llegar ahí
			        	 contador++;//indicamos que lo que sigue es otra mesa
			        	 if(sensor.CercaDeLibro()){//Ya que llegamos a la mesa, ¿Hay algún libro?
			        	  actuador.RecogerLibro(sensor.GetLibro());//Si encontramos uno, lo cargamos
			        	 }
			        	}
			        	actuador.Flotar();
			        }


				}else{//TERMINANDO RECORRIDO DE MESAS O CARGA DE LIBROS LLENA

					//Vamos hacia la zona de desinfección
					float distanciaZona = Vector3.Distance(zonaDeDesinfeccion, sensor.posicion) - sensor.posicion[1] + zonaDeDesinfeccion[1];//Qué tan lejos estamos de la zona de desinfección
					if(distanciaZona != 0){//Si aún no llegamos
						actuador.avanzar(zonaDeDesinfeccion[0],zonaDeDesinfeccion[2]);//Seguimos avanzando hacia la zona
						actuador.Detener();
					}else{//Si llegamos
						actuador.Flotar();
						actuador.DescargarLibros();//Dejamos los libros
						if(contador == 4) contador = 0;//Si ya habíamos terminado el recorrido lo reiniciamos.
						actuador.Flotar();
					}
				
				}
			}
		}else{//DETECTAMOS QUE NO NOS QUEDA SUFICIENTE BATERÍA

			//Vamos hacia nuestra base de carga
			float distBase = Vector3.Distance(baseDeCarga, sensor.posicion) - sensor.posicion[1] + baseDeCarga[1];//Qué tan lejos estamos de la base de carga? 
			if(distBase != 0 && descendiendo == 0){//Si aún no llegamos y aún no es momento de descender
				actuador.avanzar(baseDeCarga[0], baseDeCarga[2]);//Seguimos avanzando
				actuador.Detener();
			}
			if(distBase == 0){//Si llegamos a la base de carga, indicamos que vamos a bajar
				descendiendo = 1;	
			}
			if(descendiendo == 1){ //Si llego el momento de descender
				float distBase2 = Vector3.Distance(baseDeCarga, sensor.posicion) - baseDeCarga[1];//Distancia hacia abajo para descender
				if(distBase2 != 0){//Ya terminamos de descender? 
					actuador.Descender(baseDeCarga);//Si no, bajamos
					actuador.Detener();
				}
				if(distBase2 == 0){//Si ya estamos sobre la base de carga
					descendiendo = 2;//Indicamos que vamos a comenzar la carga de batería
				}
			}
			if(descendiendo == 2){//Si es momento de cargar la batería
				if(sensor.Bateria() >= 120.0f){//Si ya tenemos la batería cargada
					descendiendo = 3;//Indicamos que terminamos de cargar la batería
				}else{//Si aún no terminamos de cargar
					actuador.Detener();
					actuador.CargarBateria();//Seguimos cargando la batería
					actuador.Detener();
				}

			}
			if(descendiendo == 3){//Si terminamos de cargar, subimos de nuevo.
				Vector3 flotando = new Vector3(baseDeCarga[0], 26.0f, baseDeCarga[2]);//Punto donde queremos elevarnos
				float distBase3 = Vector3.Distance(flotando, sensor.posicion)-2;//Qué tanto nos falta subir
				if(distBase3 >= 0){//Si aún no llegamos a la altura suficiente
					actuador.Ascender(flotando);//nos seguimos elevando
					actuador.Detener();
				}
				if(distBase3 < 0){//Si ya nos elevamos lo suficiente
					descendiendo = 0;//Indicamos que seguimos con el recorrido normal
					cargar = false;//Indicamos que ya no estamos cargando
				}
			}
		}
    }


}

