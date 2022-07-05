using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPersonaje : MonoBehaviour
{
    public GameObject personajeMichi;
    public GameObject personajeNico;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void JugarConMichi()
    {
 
            personajeMichi.SetActive(true);
            personajeNico.SetActive(false);
    }

    public void JugarConNico()
    {

        personajeMichi.SetActive(false);
        personajeNico.SetActive(true);
    }

}
