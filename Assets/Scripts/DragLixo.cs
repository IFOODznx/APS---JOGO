using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLixo : MonoBehaviour
{
    private Vector3 offset;
    private bool arrastando = false;

    void Update()
    {
        // Clique inicial
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject)
            {
                arrastando = true;
                offset = transform.position - (Vector3)mousePos;
            }
        }

        // Arrastando
        if (Input.GetMouseButton(0) && arrastando)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (Vector3)mousePos + offset;
        }

        // Soltou
        if (Input.GetMouseButtonUp(0))
        {
            arrastando = false;
        }
    }
}
