using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CellDoorOpen : MonoBehaviour
{
    public GameObject Door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
        }
    }
}
