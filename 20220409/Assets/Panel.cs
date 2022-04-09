using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    //����һ��ͼ������洢����ͼ��
    public Image panelImage;
    //����һ���������ߴ�����ʾ��������
    public AnimationCurve showCurve;
    //����һ���������ߴ������ض�������
    public AnimationCurve hideCurve;
    //����һ�����������涯���Ĳ�������
    public float animationSpeed;

    //����һ��Э�̷���������ʾ���
    IEnumerator showPanel()
    {
        //��ʼ��һ����ʱ��
        float timer = 0;
        //�����ͼ��Ĳ�͸����С��1ʱ����ѭ��
        while(panelImage.color.a < 1)
        {
            //���ͼ��Ĳ�͸���ȵ�����ʾ���������϶�Ӧ��ʱ��ʱ����ֵ
            panelImage.color = new Vector4(1, 1, 1, showCurve.Evaluate(timer));
            //���Ӽ�ʱ��ʱ��
            timer += Time.deltaTime * animationSpeed;
            //�ȴ�һ֡
            yield return null;
        }
    }

    //����һ��Э�̷��������������
    IEnumerator hidePanel()
    {
        //��ʼ��һ����ʱ��
        float timer = 0;
        //�����ͼ��Ĳ�͸���ȴ���0ʱ����ѭ��
        while (panelImage.color.a > 0)
        {
            //���ͼ��Ĳ�͸���ȵ�����ʾ���������϶�Ӧ��ʱ��ʱ����ֵ
            panelImage.color = new Vector4(1, 1, 1, hideCurve.Evaluate(timer));
            //���Ӽ�ʱ��ʱ��
            timer += Time.deltaTime * animationSpeed;
            //�ȴ�һ֡
            yield return null;
        }
    }

    private void Update()
    {
        //����������
        if(Input.GetMouseButtonDown(0))
        {
            //ֹͣ����Э��
            StopAllCoroutines();
            //������ʾ���Э��
            StartCoroutine(showPanel());
        }
        //��������Ҽ�
        else if (Input.GetMouseButtonDown(1))
        {
            //ֹͣ����Э��
            StopAllCoroutines();
            //�����������Э��
            StartCoroutine(hidePanel());
        }
    }
}
