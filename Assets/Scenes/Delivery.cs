using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float delay = 0.3f;
    private bool hasPackage;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer1;
    public Sprite packOn;
    public Sprite packOff;
    public int i = 1;
    Vector3[] spawnpos = new Vector3[22] { new Vector3(-83.6999969f, 38.9000015f, 0), new Vector3(-22.2000008f, 22.8999996f, 0), new Vector3(-77.5999985f, 3.79999995f, 0), new Vector3(-11.3000002f, 22.5f, 0), new Vector3(-56.7000008f, -2.30000114f, 0), new Vector3(-1.70000076f, 21.5999985f, 0), new Vector3(-78.4000015f, -36.8000031f, 0), new Vector3(-50.9000015f, -63.1999969f, 0), new Vector3(1.40000153f, 10, 0), new Vector3(-24.6000004f, -19.1999989f, 0), new Vector3(-57.7999992f, -30.5000019f, 0), new Vector3(-22.7000008f, -56, 0), new Vector3(0, 0, 0), new Vector3(-35.9000015f, -27, 0), new Vector3(-35.7999992f, -55.7999954f, 0), new Vector3(-2, -54.6999969f, 0), new Vector3(-35.4000015f, -6.60000038f, 0), new Vector3(-23.7000008f, -14, 0), new Vector3(1.20000076f, -43.4000015f, 0), new Vector3(-12.2000008f, -55.4000015f, 0), new Vector3(-12.9000015f, -7.39999962f, 0), new Vector3(-13.5999985f, -27.1000004f, 0) };

    void spawn()
    {
        Instantiate(spriteRenderer1, spawnpos[i], Quaternion.identity);
        i++;
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
            spawn();
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            Invoke("changeBack",delay);
        }
    }
}
