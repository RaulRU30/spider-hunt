using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hitEffect; // Efecto visual al ser alcanzado
    public Animator enemyAnimator; // Referencia al animador si tienes una animación para el enemigo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Bala colisionó con el enemigo!");

            // Activar el efecto visual (ejemplo: explosión)
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            // Activar la animación de muerte
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die"); // Activar el trigger "Die"
            }
            Destroy(gameObject, 2f);
        }
    }
}



