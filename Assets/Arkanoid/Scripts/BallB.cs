using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallB : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade = 10;
    public Vector2 direcao;
    
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Vector2.zero;
        DispararBolinha(0);
    }

    public void DispararBolinha(float inputX)
    {
        direcao = new Vector2(inputX, 1);
        rb.velocity = direcao.normalized * velocidade;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            direcao += col.gameObject.GetComponent<PlayerB>().direcaoPlayer;
            direcao.Normalize();
        }

        if (col.gameObject.CompareTag("Tijolo"))
        {
            Destroy(col.gameObject);
        }
        

        direcao = Vector2.Reflect(direcao, col.contacts[0].normal);
        rb.velocity = direcao.normalized * velocidade;
    }
}
