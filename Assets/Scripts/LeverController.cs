using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Vector3 direction;

    public GameObject pivotPoint;

    public float rotateSpeed;
    public float rotateTime;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Data.leverIsPulled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.leverIsPulled == true && elapsedTime < rotateTime)
        {
            pivotPoint.transform.Rotate(direction * rotateSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Data.leverIsPulled = true;
        }
    }

}
