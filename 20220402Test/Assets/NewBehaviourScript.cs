using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript Instance;

    #region Properties

    [Header("HeaderOne")]     //这是标题头

    public string name = "BlueBox";

    public int number = 15;

    public string description = "Test";

    bool isPlaying = false;

    private string portStatus = "";
    public string PortStatus
    {
        get { return portStatus; }
        set { portStatus = value; }
    }

    [Header("HeaderTwo")]     //这是标题头

    public Text TestText;
    public Text Test2Text;


    public enum TestSee
    { CanSeePrivate, CanNotSeePrivate }

    [Header("HeaderThree")]
  
    public TestSee Choose =
        TestSee.CanSeePrivate;

    //[SerializeField]  //用于private类型在属性视图中可见
    [SerializeField]
    private bool CanSee = true;

    #endregion Properties


    public void PrintfTest()
    {
        Debug.Log("newScript.name");
        Debug.Log(name);
    }
}
