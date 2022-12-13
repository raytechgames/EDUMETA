using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PARKPHYCaccurate : MonoBehaviour
{
    public Text trigtext;
    public bool parkcorrect = false;
    public GameObject correct,wrong;
    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
        {
            trigtext.text = "Nice parking";
            parkcorrect = true;
        }
           

        
    }
    public void done()
    {
        if (parkcorrect == true)
        {
            correct.SetActive(true);
        }
        if (parkcorrect == false)
        {
            wrong.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parkcorrect = true;
            trigtext.text = "Nice parking";
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        parkcorrect = false;
        trigtext.text = "you are a little off try again";
    }
    
}
