using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCtrlBlock : MonoBehaviour
{
    public int fanId = 0;
    public bool blkEnabled = false;
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 canvasPosition = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 snapPosition_0 = new Vector3(0.0f, 3.75f, 0.0f);
    private Vector3 snapPosition_1 = new Vector3(0.0f, 2.25f, 0.0f);

    void Awake()
    {
        snapPosition_0 = snapPosition_0 + canvasPosition;
        snapPosition_1 = snapPosition_1 + canvasPosition;
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
        if (transform.position.x > snapPosition_0.x - 0.375f && transform.position.x < snapPosition_0.x + 0.375f && transform.position.y > snapPosition_0.y - 0.875f && transform.position.y < snapPosition_0.y + 0.875f)
        {
            transform.position = snapPosition_0;
            blkEnabled = true;
            Debug.Log("Snapped to Position 0");
        }
        else if (transform.position.x > snapPosition_1.x - 0.375f && transform.position.x < snapPosition_1.x + 0.375f && transform.position.y > snapPosition_1.y - 0.875f && transform.position.y < snapPosition_1.y + 0.875f)
        {
            transform.position = snapPosition_1;
            blkEnabled = true;
            
            Debug.Log("Snapped to Position 1");
        }
        else
        {
            blkEnabled = false;
        }
    }
}
