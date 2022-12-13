using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZoomLivechat : MonoBehaviour
{
    public TMP_InputField zoomLink;
    
    public void OpenZoomLink()
    {
        Application.OpenURL(zoomLink.text);
        if(zoomLink.text == "")
        {
            zoomLink.text = "Please enter valid link";
        }
    }
}
