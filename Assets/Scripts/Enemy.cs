using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hitEffect; 
    public Animator enemyAnimator; 
    
    private bool _isDead = false; 
    
    public AudioClip deathSound;
    [Range(0f, 1f)]
    public float deathVolume = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !_isDead)
        {
            _isDead = true;
            
            if (deathSound != null)
            {
                Debug.Log("Reproduciendo sonido de muerte.");
                AudioSource.PlayClipAtPoint(deathSound, transform.position, deathVolume);
            }
            
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
            
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die");
            }
            Destroy(gameObject, 1f);
            
            if (GameController.instance != null)
            {
            }
            
            Destroy(other.gameObject);

        }
    }
}



