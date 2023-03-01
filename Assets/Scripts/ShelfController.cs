using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    public Vector3 direction;

    public float slideSpeed;
    public float slideTime;
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Data.hasBook == true && elapsedTime < slideTime)
        {
            transform.Translate(direction * slideSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Data.hasBook = false;
            elapsedTime = 0f;
        }

    }
}
