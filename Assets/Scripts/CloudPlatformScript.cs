using UnityEngine;
using System.Collections;

public class CloudPlatformScript : MonoBehaviour
{
    public float timeForDestroy, timeForRegenerate;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("COLLIDE");
        if (other.gameObject.tag == "Player")
        {
           
            Debug.Log("ATTENTO");
            Invoke("DestroyPlatform", timeForDestroy);
            Invoke("RegeneratePlatform", timeForRegenerate);
        }
      
    }

   

    void DestroyPlatform()
    {
        spriteRenderer.color = Color.red;
        //gameObject.SetActive(false);
        boxCollider.enabled = false;
    }

    void RegeneratePlatform()
    {
        spriteRenderer.color = Color.white;
        //gameObject.SetActive(true);
        boxCollider.enabled = true;
    }

}
