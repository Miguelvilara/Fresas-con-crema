using UnityEngine;

public class ZanahoriaMov : MonoBehaviour
{
   
    public Animator animator;
    public string triggerAvanzar = "AnimacionCambio";
    public string triggerRegresar = "Retorno";

    // Funci�n que llama el bot�n
    public void ActivarAnimacion()
    {
        if (animator != null)
        {
            // Verifica en qu� estado est� la animaci�n
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


