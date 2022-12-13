using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PARKPHYC : MonoBehaviour
{
    public Text trigtext;
    public bool parkcorrect = false;
    public GameObject wrong;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trigtext.text="you are a little off try again";
            parkcorrect = false;

        }
    }
    public void done()
    {
        if(parkcorrect==false)
        {
            //wrong.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigtext.text = "you are a little off try again";
            parkcorrect = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
       // trigtext.text = "";
    }
}
