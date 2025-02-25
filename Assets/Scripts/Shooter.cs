using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // La bala que se instanciará
    public Transform gunTransform; // Posición desde donde se disparará
    public float bulletSpeed = 10f; // Velocidad de la bala
    public GameObject crosshair; // Mira fija (opcional)

    // Método para disparar
    public void FireBullet()
    {
        // Crear la bala en la posición del cañón
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);

        // Obtener el Rigidbody para aplicar física
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Ajustamos la rotación para que la bala se alinee correctamente
        bullet.transform.rotation = Quaternion.Euler(0f, gunTransform.rotation.eulerAngles.y, 0f); // Ajustamos solo el eje Y

        // Si es necesario, ajustar el ángulo Z de la bala para que se dispare de manera correcta
        bullet.transform.Rotate(0, -90f, -90f); // Ajuste para corregir la rotación Z de la bala

        // Aplicar velocidad a la bala en la dirección hacia donde apunta el cañón
        bulletRb.velocity = gunTransform.forward * bulletSpeed;
    }
}
