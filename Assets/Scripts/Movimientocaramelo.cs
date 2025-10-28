using UnityEngine;

public class Movimientocaramelo : MonoBehaviour
{
    public Animator animator;
    public string triggerAvanzar = "CambiarAnim";
    public string triggerRegresar = "Regresar";

    // Función que llama el botón
    public void ActivarAnimacion()
    {
        if (animator != null)
        {
            // Verifica en qué estado está la animación
            AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);

            if (estado.IsName("CARAMELO1"))
            {
                animator.SetTrigger(triggerAvanzar);
            }
            else if (estado.IsName("CARAMELOMOV"))
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
