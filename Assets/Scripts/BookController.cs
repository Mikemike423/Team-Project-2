using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    private void Start()
    {
        Data.hasBook = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("bookTouch");

            Data.hasBook = true;
            gameObject.SetActive(false);
        }
    }
}
