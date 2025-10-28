using UnityEngine;
using UnityEngine.SceneManagement; // <- Esta línea es esencial

public class Botones : MonoBehaviour

{

    public void Jugar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Botón presionado, cargando escena...");
    }

    public void Segundo()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Botón presionado, cargando escena...");
    }
    public void Tercero()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        Debug.Log("Botón presionado, cargando escena...");
    }


    public void Salir()
    { }




}