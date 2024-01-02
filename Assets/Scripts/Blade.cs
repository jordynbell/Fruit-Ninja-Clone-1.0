using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;

    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        col.enabled = IsMouseMoving();

        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float travelled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (travelled > minVelo) 
            return true;
        else 
            return false;
    }

}
