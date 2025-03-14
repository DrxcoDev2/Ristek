using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreaker : MonoBehaviour
{
    public float reachDistance = 5f;    // Distancia de alcance del rayo
    public Camera playerCamera;         // C�mara del jugador
    public GameObject crosshair;        // Mira en la pantalla

    void Start()
    {
        // Asegurarse de que el cursor est� visible y no est� bloqueado
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Hacer el raycast cuando el jugador haga clic izquierdo
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            // Creamos un raycast desde la posici�n del rat�n en la pantalla hacia el mundo
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                // Si el rayo impacta con un bloque (comprobamos el tag "Block")
                if (hit.collider.CompareTag("Block"))
                {
                    Destroy(hit.collider.gameObject); // Destruir el bloque
                }
            }
        }
    }
}
