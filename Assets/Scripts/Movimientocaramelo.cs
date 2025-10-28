using UnityEngine;

public class Movimientocaramelo : MonoBehaviour
{
    public Animator animator;
    public string triggerAvanzar = "CambiarAnim";
    public string triggerRegresar = "Regresar";

    // Funci�n que llama el bot�n
    public void ActivarAnimacion()
    {
        if (animator != null)
        {
            // Verifica en qu� estado est� la animaci�n
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
