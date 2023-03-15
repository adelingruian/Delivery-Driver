using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float normalSpeed = 6f;
    [SerializeField] float boostedSpeed = 10f;

    float moveSpeed;

    void Start()
    {
        moveSpeed = normalSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Speed-up") {
            moveSpeed = boostedSpeed;
        }
        else {
            moveSpeed = normalSpeed;
        }
    }
}
