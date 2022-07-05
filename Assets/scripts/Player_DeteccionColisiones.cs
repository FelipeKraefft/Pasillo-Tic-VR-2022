using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script es exclusivo para la misión búsqueda del tesoro

public class Player_DeteccionColisiones : MonoBehaviour
{
    public string tagBuscado = "";
    public Mision_00_BuscaTesoro mision;
    public AudioSource audioSource;
    public AudioClip clipObejtoTocado;

    public void ResetearBusqueda()
    {
        tagBuscado = "";
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == tagBuscado && tagBuscado != "")
        {
            collision.gameObject.SetActive(false);
            mision.ObjetoEncontrado(collision.gameObject.name);
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clipObejtoTocado;
            audioSource.Play();
        }
    }
}
