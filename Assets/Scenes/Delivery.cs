using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float delay = 0.3f;
    private bool hasPackage;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer post1;
    public SpriteRenderer post2;
    public Sprite rick;
    public Sprite packOn;
    public Sprite packOff;
    public TMP_Text score;
    public int i = 0; 
    Vector3[] spawnpos = new Vector3[22] { new Vector3(-35, 23.1000004f, 0), new Vector3(-22.2000008f, 22.8999996f, 0), new Vector3(-77.5999985f, 3.79999995f, 0), new Vector3(-11.3000002f, 22.5f, 0), new Vector3(-56.7000008f, -2.30000114f, 0), new Vector3(-1.70000076f, 21.5999985f, 0), new Vector3(-78.4000015f, -36.8000031f, 0), new Vector3(-50.9000015f, -63.1999969f, 0), new Vector3(1.40000153f, 10, 0), new Vector3(-24.6000004f, -19.1999989f, 0), new Vector3(-57.7999992f, -30.5000019f, 0), new Vector3(-22.7000008f, -56, 0), new Vector3(0, 0, 0), new Vector3(-35.9000015f, -27, 0), new Vector3(-35.7999992f, -55.7999954f, 0), new Vector3(-2, -54.6999969f, 0), new Vector3(-35.4000015f, -6.60000038f, 0), new Vector3(-23.7000008f, -14, 0), new Vector3(1.20000076f, -43.4000015f, 0), new Vector3(-12.2000008f, -55.4000015f, 0), new Vector3(-12.9000015f, -7.39999962f, 0), new Vector3(-13.5999985f, -27.1000004f, 0) };
    private Vector3 dir;
    // private Vector3 post1 = new Vector3(10.3000002f, -13.3000002f, 0);
    // private Vector3 post2 = new Vector3(9.39999962f, -51.5f, 0);

    void spawn()
    {
        i++;
        Instantiate(spriteRenderer1, spawnpos[i], Quaternion.identity);
    }
    
    void change()
    {
        spriteRenderer.sprite = packOn;
    }

    void changeBack()
    {
        spriteRenderer.sprite = packOff;
    }

    public void LateUpdate()
    {
        score.text = "Score : " + i.ToString();
        Debug.Log("In LateUpdate "+ hasPackage);
        spriteRenderer2.transform.position = transform.position;
        if (hasPackage)
        {
            spriteRenderer2.color = Color.white;
            Debug.Log("Post1 pos " + post1);
            if (Vector3.Distance(post1.transform.position, spriteRenderer2.transform.position) <
                Vector3.Distance(post2.transform.position, spriteRenderer2.transform.position))
                dir = post1.transform.position - spriteRenderer2.transform.position;
            else
                dir = post2.transform.position - spriteRenderer2.transform.position;
        }
        else
        {

            spriteRenderer2.color = new Color(212, 73, 209);
            dir = spawnpos[i] - spriteRenderer2.transform.position;
        }
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spriteRenderer2.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
            if (i == 22)
            {
                spriteRenderer.sprite = rick;
                transform.localScale = new Vector3(2, 2, 2);
            }
            else
            {
                Debug.Log("Package delivered");
                hasPackage = false;
                Invoke("changeBack", delay);
            }
        }
    }
}
