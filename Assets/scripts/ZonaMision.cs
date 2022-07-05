using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZonaMision : MonoBehaviour
{
    public int idZona;
    MisionManager misionMgr;
    public GameObject objetoMision;
    public GameManager GM;

    public string deskTxtMsn;
    public string mobTxtMsn;
    public string deskTxtNoCompletada;
    public string mobTxtNoCompletada;
    public string deskTxtCompletada;
    public string mobTxtCompletada;
    public string deskTxtFallida;
    public string mobTxtFallida;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        misionMgr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MisionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
       
            //le paso a misionMgr este objeto para que pueda devolver el mensaje y activar la mision
            misionMgr.areaActivadora = this.gameObject;
            //chequea si es mobile o desktop para mostrar mensajes adecuados a los controles
            //le pasa a MISIONMANAGER los textos que se deben mostrar en el panelMision
            if (!GM.mobile)
            {
                misionMgr.textoMision = deskTxtMsn;
                misionMgr.textoMisionCompletada = deskTxtCompletada;
                misionMgr.textoMisionFallida = deskTxtFallida;
                misionMgr.textoMisionNoCompletada = deskTxtNoCompletada;

            }
            else
            {
                misionMgr.textoMision = mobTxtMsn;
                misionMgr.textoMisionCompletada = mobTxtCompletada;
                misionMgr.textoMisionFallida = mobTxtFallida;
                misionMgr.textoMisionNoCompletada = mobTxtNoCompletada;
            }

            misionMgr.ActivarPanelMision(idZona);
        }
    }

}
