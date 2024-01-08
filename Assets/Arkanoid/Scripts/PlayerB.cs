using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade = 10;
    public float inputX;
    public Vector2 direcaoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        direcaoPlayer = new Vector2(inputX, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = direcaoPlayer * velocidade;
    }
}
