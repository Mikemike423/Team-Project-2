using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
   public NavMeshAgent enemy;
   public Transform Player;

   public GameObject Start;

   public bool hidden;
  
  



   private void Update()
   {
   
     chasePlayer();
 
   
     
   }
  
 


   private void chasePlayer()
   {
    enemy.SetDestination(Player.position);

    transform.LookAt(Player);
   }
  
}
