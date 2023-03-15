using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{   
    [SerializeField] Color32 hasPackageColor = new Color32(225,50,50,255);
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);
    
    [SerializeField] float time = 0f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D() {
        Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Pick-up" && !hasPackage)
        {
            Debug.Log("Package picked up.");
            hasPackage = true;
            Destroy(other.gameObject, time);
            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Delivery" && hasPackage)
        {
            Debug.Log("Delivered package.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
