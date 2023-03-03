using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
   public NavMeshAgent enemy;
   public Transform Player;

   public GameObject Start;

   //bool to store if player is hiding
   public bool hidden = false;

   //bool for if player has left starting area
   public bool playerLeftStart = false;
  
   private void Update()
   {
      if(playerLeftStart && !hidden) chasePlayer(); 
   }
  
   private void chasePlayer()
   {
    enemy.SetDestination(Player.position);

    transform.LookAt(Player);
   }
   
}
