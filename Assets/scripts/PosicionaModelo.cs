using UnityEngine;
using System.Collections;

public class PosicionaModelo : MonoBehaviour {

	public GameObject referencia;
	private float tamanio;
	private float rotacion;
	public float valorEscala;
	public float valorRotacion;
	public float valorPosicion;
 	// Use this for initialization
	void Start () {

		transform.SetParent(referencia.transform);

		tamanio = 1f;
		valorEscala = 0.01f;
		valorPosicion = 0.002f;

	}
	
	// Update is called once per frame
	void Update () {
		// la U aumenta la escala
		if (Input.GetKey (KeyCode.U)) {
			tamanio = tamanio + valorEscala;
			referencia.transform.localScale = new Vector3 (tamanio, tamanio, tamanio);
		}
		//la J reduce la escala
		if (Input.GetKey (KeyCode.J)) {
			tamanio = tamanio - valorEscala;
			referencia.transform.localScale = new Vector3 (tamanio, tamanio, tamanio);
			}
		//la I gira 2 grados el modelo
		if (Input.GetKey (KeyCode.I)) {
			transform.Rotate (2f, 0f, 0f);
		}
		//la K gira -2 grados el modelo
		if (Input.GetKey (KeyCode.K)) {
			transform.Rotate (-2f, 0f, 0f);
		}
		//la O y la L desplazan lateralmente el modelo
		if (Input.GetKey (KeyCode.O)) {
			transform.Translate (valorPosicion, 0f, 0f);
		}
		if (Input.GetKey (KeyCode.L)) {
			transform.Translate (- valorPosicion, 0f, 0f);
		}
		if (Input.GetKey (KeyCode.Y)) {
			transform.Translate (0f, valorPosicion, 0f, Space.World);
		}
		if (Input.GetKey (KeyCode.H)) {
			transform.Translate (0f, - valorPosicion, 0f, Space.World);
		}
	}
}
