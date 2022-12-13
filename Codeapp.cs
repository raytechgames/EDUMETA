using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Codeapp : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text OutputText,compileText,typedText,correct;
    public bool isCorrect = false;
  
    private void Start()
    {
       
    }
    public void Compile()
    {

        OutputText.text = typedText.text;

       

        
            compileText.text = "compiled succesfully";
        




    }

    private void Update()
    {

        

        
        
    }
}
