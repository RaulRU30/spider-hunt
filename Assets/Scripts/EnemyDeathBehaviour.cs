using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : StateMachineBehaviour
{
    // Este método se llama cuando la animación de muerte ha terminado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Espera a que termine la animación
        if (stateInfo.IsName("Die"))  // Asegúrate de que el nombre sea el mismo que el de la animación de muerte
        {
            Debug.Log("La animación de muerte ha terminado. Destruyendo al enemigo.");
            Destroy(animator.gameObject); // Destruye el enemigo
        }
    }
}
