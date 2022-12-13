using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{

    PlayerController player;


    private void Awake()
    {
        
        player = GetComponent<PlayerController>();
    }
  
    private void OnTriggerEnter(Collider other)
    {
       
        player.SetGroundState(true);
    }
    private void OnTriggerExit(Collider other)
    {
       
            player.SetGroundState(false);
        
       
    }
    private void OnTriggerStay(Collider other)
    {
        
        player.SetGroundState(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        player.SetGroundState(true);
    }
    private void OnCollisionExit(Collision collision)
    {
       
        player.SetGroundState(false);
    }
    private void OnCollisionStay(Collision collision)
    {
       
        player.SetGroundState(true);
    }
}
