using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    public Sprite[] popSprites;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PopBalloon()
    {
        rigidBody.freezeRotation = true;
        rigidBody.velocity = new Vector2(0.0f, 0.0f);
        spriteRenderer.sprite = popSprites[0];
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = popSprites[1];
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = popSprites[2];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle") {
            StartCoroutine(PopBalloon());
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "CompleteLevel") {
            //transform.Translate(new Vector3(0,0,0));  // stop moving
            //transform.Rotate(new Vector3(0,0,0));  // stop rotating
            rigidBody.gravityScale = 0.0f;  // stop it falling to ground
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}
