using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    //声明一个图像组件存储面板的图像
    public Image panelImage;
    //声明一个动画曲线储存显示动画曲线
    public AnimationCurve showCurve;
    //声明一个动画曲线储存隐藏动画曲线
    public AnimationCurve hideCurve;
    //声明一个浮点数储存动画的播放速率
    public float animationSpeed;

    //声明一个协程方法用于显示面板
    IEnumerator showPanel()
    {
        //初始化一个计时器
        float timer = 0;
        //当面板图像的不透明度小于1时进行循环
        while(panelImage.color.a < 1)
        {
            //面板图像的不透明度等于显示动画曲线上对应计时器时间点的值
            panelImage.color = new Vector4(1, 1, 1, showCurve.Evaluate(timer));
            //增加计时器时间
            timer += Time.deltaTime * animationSpeed;
            //等待一帧
            yield return null;
        }
    }

    //声明一个协程方法用于隐藏面板
    IEnumerator hidePanel()
    {
        //初始化一个计时器
        float timer = 0;
        //当面板图像的不透明度大于0时进行循环
        while (panelImage.color.a > 0)
        {
            //面板图像的不透明度等于显示动画曲线上对应计时器时间点的值
            panelImage.color = new Vector4(1, 1, 1, hideCurve.Evaluate(timer));
            //增加计时器时间
            timer += Time.deltaTime * animationSpeed;
            //等待一帧
            yield return null;
        }
    }

    private void Update()
    {
        //按下鼠标左键
        if(Input.GetMouseButtonDown(0))
        {
            //停止所有协程
            StopAllCoroutines();
            //运行显示面板协程
            StartCoroutine(showPanel());
        }
        //按下鼠标右键
        else if (Input.GetMouseButtonDown(1))
        {
            //停止所有协程
            StopAllCoroutines();
            //运行隐藏面板协程
            StartCoroutine(hidePanel());
        }
    }
}
