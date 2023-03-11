using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Libros : MonoBehaviour {
	/*Este método es para agregar un nuevo libro en una posición al azar en la mesa dada*/
	public static GameObject NuevoLibro(GameObject mesa){
		GameObject libro = GameObject.Find("Libro");//Esta es nuestra referencia
		int x = Range(-8,8);//posición x al azar
		int z = Range(-8,8);//posición z al azar
		Vector3 posicion = new Vector3(mesa.transform.position[0]+x, 8.3f, mesa.transform.position[2] + z);//Preparamos la posición del nuevo libro
		GameObject libronuevo = (GameObject) Instantiate(libro, posicion, mesa.transform.rotation);//Iniciamos el nuevo libro
		return libronuevo;
	}


}