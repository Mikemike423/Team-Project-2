using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeverController : MonoBehaviour
{
    public Vector3 direction;

    public GameObject pivotPoint;

    public float rotateSpeed;
    public float rotateTime;
    private float elapsedTime = 0f;

     public TextMeshProUGUI interactText;

    AudioSource sound;
    public AudioSource openSound;

    // Start is called before the first frame update
    void Start()
    {
        Data.leverIsPulled = false;
        interactText.text = " ";
        sound = GetComponent<AudioSource>();
        openSound = openSound.GetComponent<AudioSource>();
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
        if (Input.GetKey(KeyCode.E))
        {
            Data.leverIsPulled = true;
            openSound.Play();
        }
        
    
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           interactText.text = "Press E";

        }

         
      
    }
        private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           interactText.text = " ";

        }

         
      
    }
    


}
