using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Libros : MonoBehaviour {
	public static GameObject NuevoLibro(GameObject mesa){
		GameObject libro = GameObject.Find("Libro");
		int x = Range(-8,8);
		int z = Range(-8,8);
		Vector3 posicion = new Vector3(mesa.transform.position[0]+x, 8.3f, mesa.transform.position[2] + z);
		GameObject libronuevo = (GameObject) Instantiate(libro, posicion, mesa.transform.rotation);
		return libronuevo;
	}


}