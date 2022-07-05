using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mision_00_BuscaTesoro : MonoBehaviour
{
    GameObject playerGO;
    public List<GameObject> tesoros;
    public List<GameObject> lugares;

    public string nombreMision;
    public MisionManager misionMgr;
    public GameManager GM;

    public GameObject panelAuxMision;
    Animator animPanelAux;

    public Image imgT;
    public Image imgI;
    public Image imgC;

    public int cantEncontrados;

    public float imgAlphainicial;

    public AudioSource audioSource;
    public AudioClip clipWin;

    void Start()
    {
        //referencias a objetos externos Player y MisionMgr
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        misionMgr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MisionManager>();

        //popula las listas de lugares y tesoros por tag
        lugares.AddRange(GameObject.FindGameObjectsWithTag("posicionTesoro"));
        tesoros.AddRange(GameObject.FindGameObjectsWithTag("tesoro1"));

        //chequea que haya la misma cantidad de lugares y tesoros
        if (lugares.Count != tesoros.Count)
        {
            Debug.Log("CANTIDAD DE LUGARES Y TESOROS NO COINCIDEN");
            Debug.Log("Lugares: " + lugares.Count + " - Tesoros: " + tesoros.Count);
        }

        //carga el animator y activa la animación de mostrar el panel
        animPanelAux = panelAuxMision.GetComponent<Animator>();
        animPanelAux.SetBool("MostrarPanel", true);

        //*********CAMBIAR ESTA LOGICA CUANDO SE PUEDA************
        SetImgAlpha(imgT, imgAlphainicial);
        SetImgAlpha(imgI, imgAlphainicial);
        SetImgAlpha(imgC, imgAlphainicial);

        //Prepara y comienza la misión
        UbicarTesoros();
        ComenzarLaBusqueda();
    }

    public void ObjetoEncontrado(string tesoro)
    {
        //y acá se fija si es para ORT o para TIC
        //esta es una cosa ESPANTOSA donde HARDCODEO EL NOMBRE del objeto para detectarlo, pido perdón

        if (GM.versionORT)
        {
            switch (tesoro)
            {
                case "Tesoro_Letra_O":
                    SetImgAlpha(imgT, 1f);
                    break;
                case "Tesoro_Letra_R":
                    SetImgAlpha(imgI, 1f);
                    break;
                case "Tesoro_Letra_T":
                    SetImgAlpha(imgC, 1f);
                    break;
            }
        }
        else
        {
            switch (tesoro)
            {
                case "Tesoro_Letra_T":
                    SetImgAlpha(imgT, 1f);
                    break;
                case "Tesoro_Letra_I":
                    SetImgAlpha(imgI, 1f);
                    break;
                case "Tesoro_Letra_C":
                    SetImgAlpha(imgC, 1f);
                    break;
            }

        }

        cantEncontrados++;

        //chequear si se encontraron todos los objetos
        if (busquedaCompletada(cantEncontrados))
        {
            TerminarMision();
        }
    }

    bool busquedaCompletada(int encontrados)
    {
        bool retorno = false;
        if (encontrados >= tesoros.Count)
        {
            retorno = true;
        }

        return retorno;
    }

    void TerminarMision(){
        misionMgr.misionCumplida = true;
        audioSource.clip = clipWin;
        audioSource.Play();
        //animPanelAux.SetBool("MostrarPanel", false);
    }

    void ComenzarLaBusqueda()
    {
        playerGO.GetComponent<Player_DeteccionColisiones>().tagBuscado = "tesoro1";
    }
    
    void UbicarTesoros()
    {
        int iTesoros = 0;
       while(lugares.Count > 0)
        {
            int posRandom = GenerarPosicionRandom();
            GameObject tesoroClon = Instantiate(tesoros[iTesoros], lugares[posRandom].GetComponent<Transform>().position, Quaternion.identity);
            string nombreCorto = tesoroClon.name.Substring(0, 14);
            tesoroClon.name = nombreCorto;
            tesoroClon.transform.Rotate(-90,0,0);
            lugares.RemoveAt(posRandom);
            iTesoros++;
        }
        cantEncontrados = 0;
    }

     int GenerarPosicionRandom()
    {
        int posicion = Random.Range(0, lugares.Count);
        return posicion;
    }

    void SetImgAlpha(Image image,float value) {
        var tempColor = image.color;
        tempColor.a = value;
        image.color = tempColor;
    }
  

}
