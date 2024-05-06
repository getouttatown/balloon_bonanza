using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool fanEnabled = false;
    public int fanId = 0;

    private bool fanSpriteEnabled = false;
    private SpriteRenderer spriteRenderer;
    private AreaEffector2D areaEffector;
    public Sprite[] fanSprites;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        areaEffector = GetComponentInChildren<AreaEffector2D>();
        DisableFan();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fanEnabled && !fanSpriteEnabled) {
            EnableFan();
        }
        else if (!fanEnabled && fanSpriteEnabled) {
            DisableFan();
        }
    }

    private void EnableFan()
    {
        spriteRenderer.sprite = fanSprites[1];
        fanSpriteEnabled = true;
        areaEffector.forceMagnitude = 1.0f;
    }

    private void DisableFan()
    {
        spriteRenderer.sprite = fanSprites[0];
        fanSpriteEnabled = false;
        areaEffector.forceMagnitude = 0.0f;
    }
}
