using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Arrastra el "Player" aqu� en Unity

    private float xRotation = 0f;
    private float yRotation = 0f;



    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotaci�n vertical (mirar arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -360f, 90f); // Limita la inclinaci�n de la c�mara

        // Rotaci�n horizontal (mirar a los lados)
        yRotation += mouseX;

        // Aplica la rotaci�n a la c�mara
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Rota el cuerpo del jugador para seguir la rotaci�n horizontal
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
