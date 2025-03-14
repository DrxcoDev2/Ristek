using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreaker : MonoBehaviour
{
    public float reachDistance = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.CompareTag("Block"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
