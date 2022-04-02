using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript Instance;

    #region Properties

    [Header("HeaderOne")]     //���Ǳ���ͷ

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

    [Header("HeaderTwo")]     //���Ǳ���ͷ

    public Text TestText;
    public Text Test2Text;


    public enum TestSee
    { CanSeePrivate, CanNotSeePrivate }

    [Header("HeaderThree")]
  
    public TestSee Choose =
        TestSee.CanSeePrivate;

    //[SerializeField]  //����private������������ͼ�пɼ�
    [SerializeField]
    private bool CanSee = true;

    #endregion Properties


    public void PrintfTest()
    {
        Debug.Log("newScript.name");
        Debug.Log(name);
    }
}
