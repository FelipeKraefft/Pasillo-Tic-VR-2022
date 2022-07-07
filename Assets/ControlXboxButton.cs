using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlXboxButton : MonoBehaviour
{
    public MisionManager misionmng;
    // Start is called before the first frame update
    void Start()
    {
        misionmng = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MisionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("xboxFire1"))
        {
            Debug.Log("1");
            misionmng.panelMision.SetActive(false);
           
            // y disparar la misión
            misionmng.areaActivadora.GetComponent<ZonaMision>().objetoMision.SetActive(true);
            misionmng.ContinueGame();

            misionmng.misionActiva = true;
        }
    }
}
