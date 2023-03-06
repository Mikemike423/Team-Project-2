using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeathSystem : MonoBehaviour
{
    public Transform Player;
    public Transform respawnPoint;

    public int lives;

    public ParticleSystem respawnParticle;

   AudioSource sound;
   public AudioSource deathSound;

   private void start()
   {
      sound = GetComponent<AudioSource>();
      deathSound = deathSound.GetComponent<AudioSource>();
   }
    
   
  
  void OnTriggerEnter(Collider other)
   {
    
      if (other.gameObject.CompareTag("Player"))
      {
         Death();
      }
 
  
    
   
   }

   private void Death()
   {

      
      Invoke(nameof(playerRespawn), 0.7f);
       deathSound.Play();
   }

   private void playerRespawn()
   {
        Player.transform.position = respawnPoint.transform.position;
        lives = lives -1;
        
        if (lives != 9)
        {
            respawnParticle.Play();
        }
   }

   
}
