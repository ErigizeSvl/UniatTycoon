using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Pantalla negra
    [SerializeField] private Image blackBG;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Funcion para cargar una escena
    public void CargarEscena(int _scene)
    {
        StartCoroutine(FadeOut(_scene));
    }

    // Funcion para devolver la escena actual
    public int EscenaActual()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    // Funcion para devolver el nombre de la escena actual
    public string NombreEscenaActual()
    {
        return SceneManager.GetActiveScene().name;
    }

    // Funcion para salir del juego
    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator FadeIn()
    {
        Color c = blackBG.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 1f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut(int _scene)
    {
        Color c = blackBG.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 1f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }

        // Cambiamos de escena
        SceneManager.LoadScene(_scene);
    }
}
