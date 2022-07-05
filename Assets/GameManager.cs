using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int personajeID;
    public GameObject[] arrayModelosPersonajes;
    public bool mobile;
    public bool versionORT;


    void Start()
    {
        personajeID = PlayerPrefs.GetInt("personaje");
        DesactivaPersonajes();
        arrayModelosPersonajes[personajeID].SetActive(true);
    }

   void DesactivaPersonajes()
    {
        for (int i = 0; i< arrayModelosPersonajes.Length;i++)
        {
            arrayModelosPersonajes[i].SetActive(false);
        }
    }
}
