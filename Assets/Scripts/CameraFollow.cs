using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Arrastra el "Player" aqu� en Unity
    public Vector3 offset = new Vector3(0, 1.6f, 0); // Ajuste de altura

    void Update()
    {
        transform.position = player.position + offset; // Sigue al jugador
    }
}
