using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCtrl : MonoBehaviour
{
    public GameObject preFab;
    public bool placed = false;

    private bool dragging = false;
    private Vector3 offset;
    private Vector3 resetPos;

    void Start()
    {
        resetPos = transform.position;
    }

    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        // Difference between the objects center and the clicked point
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        if (transform.position.x > -5.5f && transform.position.y > -2.0f)
        {
            placed = true;
            resetPos = transform.position;
        }
        else
        {
            transform.position = resetPos;
        }
    }
}
