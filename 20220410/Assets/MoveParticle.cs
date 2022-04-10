using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;

    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标

    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标

    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标

    // Start is called before the first frame update
    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        {
           
            //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；

            screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            //获取鼠标在场景中坐标

            mousePositionOnScreen = Input.mousePosition;

            //让场景中的Z=鼠标坐标的Z

            mousePositionOnScreen.z = screenPosition.z;

            //将相机中的坐标转化为世界坐标

            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

            //print("x");
            //print(mousePositionInWorld.x);
            //print("y");
            //print(mousePositionInWorld.y);
            //print("z");
            //print(mousePositionInWorld.z);

            m_ParticleSystem.transform.position = mousePositionInWorld;
        }
    }

}
