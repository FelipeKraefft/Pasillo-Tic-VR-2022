using UnityEngine;
using System.Collections;

public class CamarasControl : MonoBehaviour
{

    // Use this for initialization
    public Camera camara1;
    public Camera camara2;

    void Start()
    {
        camara1.GetComponent<Camera>().enabled = true;
        camara2.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (camara1.enabled)
            {
                camara2.enabled = true;
                camara1.enabled = false;
            }
            else
            {
                camara2.enabled = false;
                camara1.enabled = true;
            }
        }
    }

    public void ActivaEspejoRetrovisor()
    {
        camara2.enabled = true;
        camara1.enabled = false;
    }
    public void DesactivaEspejoRetrovisor()
    {
        camara2.enabled = false;
        camara1.enabled = true;
    }
}