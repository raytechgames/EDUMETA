using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool IsInteracted;
    public GameObject InteractUi;
    public GameObject Monitor;
    // launch and activity
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("We have Interacted");
            IsInteracted = true;
            InteractUi.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
       IsInteracted=false;
        Debug.Log("Out of Range");
        InteractUi.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetButton("interact") && IsInteracted==true)
        {
            Debug.Log("Success");
            InteractUi.SetActive(false);
            Monitor.SetActive(true);

        }
    }
}
