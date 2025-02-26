using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform gunTransform; 
    public float bulletSpeed = 10f; 
    public GameObject crosshair;
    
    public AudioClip shootSound;
    [Range(0f, 1f)]
    public float shootVolume = 0.7f;
    
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    
    public void FireBullet()
    {
        if (shootSound != null && audioSource != null)
        {
            Debug.Log("Reproduciendo sonido de disparo.");
            audioSource.PlayOneShot(shootSound, shootVolume);
        }

        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        bullet.transform.rotation = Quaternion.Euler(0f, gunTransform.rotation.eulerAngles.y, 0f);
        
        bullet.transform.Rotate(0, -90f, -90f);
        
        bulletRb.velocity = gunTransform.forward * bulletSpeed;
    }
}
