# 20220402Test

### 说明

1 如何使用脚本来创建属性面板

2 如何调用其他cs文件中的函数以及变量

### 内容

1 模仿串口助手面板，来创建自定义的属性面板,代码在NewBehaviourScript.cs中

```C#
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
```


2 在TestTwo文件中调用NewBehaviourScript.cs中的函数以及变量
```C#
//先将NewBehaviourScript.cs文件引入，并定义一个变量
 private NewBehaviourScript newScript;

// Start is called before the first frame update
    void Start()
    {
        //这个可以不要，目前不知道是干嘛的
        //newScript = NewBehaviourScript.Instance;
        //给变量newScript添加属性
        newScript = gameObject.AddComponent<NewBehaviourScript>();
    }
    
    //button点击事件
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
```