using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathSystem : MonoBehaviour
{
    public Transform Player;
    public Transform respawnPoint;
    
    public int lives;
    //public AudioSource deathSound;


    private void Awake()
    {
        // deathSound = deathSound.GetComponent<AudioSource>();
         lives = 3;
    }


  
  void OnTriggerEnter(Collider other)
   {
 
    Death();
    
   
   }

   private void Death()
   {

      lives = lives -1;
     // deathSound.Play();
      Invoke(nameof(playerRespawn), 1f);
   }

   private void playerRespawn()
   {
    Player.transform.position = respawnPoint.transform.position;
   }
   
}
