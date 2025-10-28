using UnityEngine;

public class ZanahoriaMov : MonoBehaviour
{
   
    public Animator animator;
    public string triggerAvanzar = "AnimacionCambio";
    public string triggerRegresar = "Retorno";

    // Función que llama el botón
    public void ActivarAnimacion()
    {
        if (animator != null)
        {
            // Verifica en qué estado está la animación
            AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);

            if (estado.IsName("Zanahoriaidle"))
            {
                animator.SetTrigger(triggerAvanzar);
            }
            else if (estado.IsName("ZanahoriaMOV"))
            {
                animator.SetTrigger(triggerRegresar);
            }
        }
        else
        {
            Debug.LogWarning("No hay un Animator asignado.");
        }
    }
}


