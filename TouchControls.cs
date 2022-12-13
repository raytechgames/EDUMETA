using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TouchControls : MonoBehaviour
{
    public FixedTouchField touchField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<PlayerController>();
       fps.LookAxis  = touchField.TouchDist;

    }
}
