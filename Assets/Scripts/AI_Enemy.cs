using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
   public NavMeshAgent enemy;
   public Transform Player;

   public GameObject Start;

   [Header("Player States")]

   //bool to store if player is hiding
   public bool playerHiding = false;

   //bool for if player has left starting area
   public bool playerLeftStart = false;

   //bool to store if player is running
   public bool playerRunning = false;

   [Header("Search Veriables")]
   //Array of serach points
   public GameObject[] searchPoint;
   //bool to keep track of if enenmy has reached a serach point
   bool hasReachedSearchPoint = true;
   //stores current serach point index
   int curPointIndex = 0;

  
   private void Update()
   {
      //if player has left start
      //if player is hidding move toward player
      //if player is hiding move to random search point
      if(playerLeftStart && !playerHiding) chasePlayer();
      if(playerLeftStart && playerHiding) Search();  
   }
  
   private void chasePlayer()
   {
      //Reset search by setting reached search point to true
      hasReachedSearchPoint = true;
      //Set destination and look at player
      enemy.SetDestination(Player.position);
      transform.LookAt(Player);
      transform.Rotate(0f, 90f, 0f, Space.Self);
    }

   //Function to handle enenmy randomly searching while player is hiding
   private void Search() {
      Debug.Log("Serching for point: " + curPointIndex);
      //If not currently on way to search point generate random search point
      if(hasReachedSearchPoint) {
         GenerateDistinctSearchPoint();
      }
      //Set destination and sets enemy to look at position
      else {
         enemy.SetDestination(searchPoint[curPointIndex].transform.position);
         transform.LookAt(searchPoint[curPointIndex].transform);
         transform.Rotate(0f, 90f, 0f, Space.Self);
      }
   }

   //Generates disctinct serach point
   private void GenerateDistinctSearchPoint(){
      //Generate index number and temporarily store it 
      int temp = Random.Range(0,5);
      //If num generated is the same as current index re run function
      if(temp == curPointIndex) GenerateDistinctSearchPoint();
      else {
         //set current seach point index to temp
         curPointIndex = temp;
         //Set bool for seraching
         hasReachedSearchPoint = false;
      }
   }

   //Called by player to cause enemy to chase faster when player is running if player is not crouching
   public void setChaseSpeed(bool isRunning) {
      if (!playerHiding) {
         playerRunning = isRunning;
         if(playerRunning) {
            this.GetComponent<NavMeshAgent>().speed = 30f;
         }
         else this.GetComponent<NavMeshAgent>().speed = 3.5f;
      }
      else this.GetComponent<NavMeshAgent>().speed = 3.5f;
   }

   void OnTriggerEnter(Collider col) {
      //If collided with serach point check if point is current point
      if (col.gameObject == searchPoint[curPointIndex]) {
         Debug.Log("Reched Point");
         hasReachedSearchPoint = true;
      }
   }

}
