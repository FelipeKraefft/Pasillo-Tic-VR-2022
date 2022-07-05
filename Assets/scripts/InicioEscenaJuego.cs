using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioEscenaJuego : MonoBehaviour
{

    public GameObject panelMision;

    // Start is called before the first frame update
    void Start()
    {
        panelMision = GameObject.FindGameObjectWithTag("PanelMision");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MostrarBienvenida()
    {

    }


}
