using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mono.CompilerServices.SymbolWriter;

public class player : MonoBehaviour
{
    Vector2 offset;

    // public bool Stop;
    // private void Update()
    // {
    //     if (!Stop)
    //         transform.position += (Vector3)Vector2.right * 3 * Time.deltaTime;
    // }
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Stop = true;
    // }

    [ContextMenu("test")]
    public void move()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right, transform.right, 50f);
        Debug.Log(hit.point);
        Vector2 diff = hit.point - (Vector2)transform.position;
        offset = diff.normalized;
        transform.DOMove(hit.point - offset, 1f, false);
    }
}
