using UnityEngine;
using UnityEngine.SceneManagement; // <- Esta l�nea es esencial

public class Botones : MonoBehaviour

{

    public void Jugar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Bot�n presionado, cargando escena...");
    }

    public void Segundo()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Bot�n presionado, cargando escena...");
    }
    public void Tercero()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        Debug.Log("Bot�n presionado, cargando escena...");
    }


    public void Salir()
    { }




}