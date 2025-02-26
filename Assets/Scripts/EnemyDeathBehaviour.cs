using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Die"))
        {
            Debug.Log("La animación de muerte ha terminado. Destruyendo al enemigo.");
            Destroy(animator.gameObject);
        }
    }
}
