using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChase : MonoBehaviour
{
    //Stores ai enenemy script object
    public AI_Enemy enemy;

    void OnTriggerEnter(Collider col){
        //Set bool on enemy for having left the starting area to true if collided with player
        if (col.tag == "Player") {
            //Debug.Log("Started");
            enemy.playerLeftStart = true;
        }
    }

}
