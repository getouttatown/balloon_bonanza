using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
    }

    public void Close()
    {
        transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
    }
}
