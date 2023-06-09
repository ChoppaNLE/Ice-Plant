using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotation : MonoBehaviour
{
    public Transform pivotPoint; // Punto de pivote alrededor del cual girará la palanca
    public float maxRotationAngle = 45f; // Ángulo máximo de rotación de la palanca
    public float rotationSpeed = 100f; // Velocidad de rotación de la palanca

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba si la colisión es con el objeto que debe activar la rotación de la palanca
        if (collision.gameObject.CompareTag("Player2"))
        {
            float targetAngle = initialRotation.eulerAngles.z + maxRotationAngle;
            targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            isRotating = true;
        }
    }
}
