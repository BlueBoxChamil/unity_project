using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;

    Vector3 screenPosition;//���������������ת��Ϊ��Ļ����

    Vector3 mousePositionOnScreen;//��ȡ�������Ļ����Ļ����

    Vector3 mousePositionInWorld;//�������Ļ����Ļ����ת��Ϊ��������

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
           
            //��ȡ���������У������У���λ�ã�ת��Ϊ��Ļ���ꣻ

            screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            //��ȡ����ڳ���������

            mousePositionOnScreen = Input.mousePosition;

            //�ó����е�Z=��������Z

            mousePositionOnScreen.z = screenPosition.z;

            //������е�����ת��Ϊ��������

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
