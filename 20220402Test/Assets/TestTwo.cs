using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTwo : MonoBehaviour
{
    private NewBehaviourScript newScript;

// Start is called before the first frame update
    void Start()
    {
        //newScript = NewBehaviourScript.Instance;
        newScript = gameObject.AddComponent<NewBehaviourScript>();
    }

    public void CCClinkTese()
    {
        //if (newScript.name != null)
        if (newScript.name == "BlueBox")
        {
            newScript.PrintfTest();
        }
        else
        {
            Debug.Log("nothing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
