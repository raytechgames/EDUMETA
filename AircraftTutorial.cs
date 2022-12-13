using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AircraftTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text tutText;
    public GameObject correct1, correct2, correct3, correct4, correct5, correct6,box;
    public bool Loop = false;
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        StartCoroutine(Tutorial());
        Loop = true;
    }
   

    IEnumerator Tutorial()
    {
       // while(Loop)
        yield return new WaitForSeconds(12f);
        tutText.text = "Here we are going to show you the simple plane controls";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 1-Rolling :using your mouse roll the plane to the left. move your mouse to the left";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 1-Rolling :using your mouse roll the plane to the Right";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 2-Pitching :using your mouse pitch the plane up by moving the mouse down";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 2-Pitching :using your mouse pitch the plane down by moving the mouse up";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 3-Yawing :using your keyboard press and hold A key to yaw left";
        yield return new WaitForSeconds(12f);
        tutText.text = "Lesson 3-Yawing :using your keyboard press and hold D key to yaw right";
        yield return new WaitForSeconds(12f);
        tutText.text = "End of lesson...now fly to the big box to complete the training...use the controls you learned";
        box.SetActive(true);
    }
    void Update()
    {
      


        if (Input.GetAxis("Mouse X") < 0 )
        {

            correct1.SetActive(true);
           
        }
        if (Input.GetAxis("Mouse X") > 0 )
        {
            correct2.SetActive(true);

           
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            correct3.SetActive(true);


        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            correct4.SetActive(true);


        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            correct5.SetActive(true);


        }
        if (Input.GetAxis("Horizontal") < 0)
        {

            correct6.SetActive(true);

        }


    }
}
