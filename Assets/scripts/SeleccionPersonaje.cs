using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 1. Los modelos que pueden usarse como pilotos deben estar tageados como "personaje" 
 en la escena y ya posicionados.*/

public class SeleccionPersonaje : MonoBehaviour
{

    public GameObject[] arrayImgPersonajes;

    public TextMeshPro txt_NombrePersonaje;

    public Text txtDebug;

    public int idPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        //se carga el array con los modelos tageados "personaje"
        //peeeroo, el orden de este array no puede establecerse, as´que lo cargamos a mano, sorry
        //arrayImgPersonajes = GameObject.FindGameObjectsWithTag("personaje");
        //oculta todos los modelos del array y activa el primero
        DesactivaImgPersonajes();
        arrayImgPersonajes[0].SetActive(true);
        txt_NombrePersonaje.text = arrayImgPersonajes[0].name;
        //inicializa la variable idPersonaje en 0
        idPersonaje = 0;
        

    }

    private void Update()
    {
        txtDebug.text = "ID personaje: " + idPersonaje;
    }

    public void AvanzaRetrocedePersonaje(int subeOBaja)
    {
        if (subeOBaja > 0)
        {
            if (idPersonaje < arrayImgPersonajes.Length-1)
            {
                idPersonaje += subeOBaja;
            }
            else
            {
                idPersonaje = 0;
            }
        }
        else
        {
            if (idPersonaje > 0)
            {
                idPersonaje += subeOBaja;
            }
            else
            {
                idPersonaje = arrayImgPersonajes.Length -1 ;
            }
        }

        DesactivaImgPersonajes();
        arrayImgPersonajes[idPersonaje].SetActive(true);
        txt_NombrePersonaje.text = arrayImgPersonajes[idPersonaje].name;
       // txtNombrePersonaje.text = arrayImgPersonajes[idPersonaje].name;

    }

    void DesactivaImgPersonajes()
    {
        for (int i = 0; i < arrayImgPersonajes.Length; i++)
        {
            arrayImgPersonajes[i].SetActive(false);
        }
    }

    public void CargarEscenaJuego()
    {
        PlayerPrefs.SetInt("personaje",idPersonaje);

        SceneManager.LoadScene(1);
    }


}
