using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Este script debearía llamarse PanelInfoManager o algo así
 --Dividir las funcionalidades de activar, desactivar y pausar el juego
 de las de asignar valor a las variables de texto
 --*/

public class MisionManager : MonoBehaviour
{
    public GameManager GM;
    public string textoMision;
    public string textoMisionNoCompletada;
    public string textoMisionCompletada;
    public string textoMisionFallida;
    Text txtMision;
    public GameObject areaActivadora;
    GameObject panelMision;
    CanvasGroup controlesCG;

    public bool misionActiva = false;
    public bool misionCumplida = false;

    public GameObject panelAuxMision;
    Animator animPanelAux;

    enum EstadoMisiones{
        CUMPLIDA, NOCOMPLETADA, FALLIDA
    }

    void Start()
    {

        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        panelMision = GameObject.FindGameObjectWithTag("PanelMision");
        //oculta el panel mision
        panelMision.SetActive(false);

        //si es mobile se referencia el canvasGroup de los controles
        if (GM.mobile)
        {
            controlesCG = GameObject.FindGameObjectWithTag("PadreControles").GetComponent<CanvasGroup>();
        }
        
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        panelMision.SetActive(false);
        AudioListener.pause = false;
    }

    public void ActivarPanelMision(int id)
    {
        panelMision.SetActive(true);
        txtMision = panelMision.GetComponentInChildren<Text>();
        //emparche toggle mobile
        if (GM.mobile)
        {
            controlesCG.alpha = 0f;
        }
        PauseGame();

        MostrarTextoEnPanelSegunEstadoMision();


    void MostrarTextoEnPanelSegunEstadoMision()
    {
            //IMPLEMENTAR SWITCH PARA LOS MENSAJES CON EL ENUM
            //txtMision.text = SeleccionarMensaje(enum);

            //si todavía no empezó la misión
            if (!misionActiva)
            {
                txtMision.text = textoMision;
            }
            else
            {
                if (misionCumplida)
                {
                    txtMision.text = textoMisionCompletada;
                    animPanelAux = panelAuxMision.GetComponent<Animator>();
                    //chequear de alguna manera que el panelAux esté visible, si no se va a reproducir de la nada esta animación
                    animPanelAux.SetBool("MostrarPanel", false);
                    misionActiva = false;
                    areaActivadora.SetActive(false);
                }
                else
                {
                    txtMision.text = textoMisionNoCompletada;
                }

            }
        }
    }

    string SeleccionarMensaje()
    {
        //devolver el string que corresponda de acuerdo al estado de la misión
        return "";
    }

    //un botón que solo cierra el panel y continua el juego
    public void buttonAceptar()
    {
        if (GM.mobile)
        {
            controlesCG.alpha = 1f;
        }
        ContinueGame();
    }
    
    public void buttonAceptarMision()
    {
        panelMision.SetActive(false);
        //emparche para saber si es versión mobile o no
        if (GM.mobile)
        {
            controlesCG.alpha = 1f;
        }
        // y disparar la misión
        areaActivadora.GetComponent<ZonaMision>().objetoMision.SetActive(true);
        ContinueGame();

        misionActiva = true;
    }    
}