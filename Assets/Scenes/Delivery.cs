using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float delay = 0.3f;
    private bool hasPackage;
    public SpriteRenderer spriteRenderer;
    public Sprite packOn;
    public Sprite packOff;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>()
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
    }

    void change()
    {
        spriteRenderer.sprite = packOn;
    }

    void changeBack()
    {
        spriteRenderer.sprite = packOff;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject,delay);
            Invoke("change",delay);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            Invoke("changeBack",delay);
        }
    }
}
