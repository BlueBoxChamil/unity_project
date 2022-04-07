using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //��ȡ���λ�õ���������
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //��ȡƻ��������λ�ò�
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    //������ײ����Χ�ڰ������ʱ
    private void OnMouseDrag()
    {
        //����ƻ��λ��
        transform.position = mousePos + distance;
        //��������Ӱ��
        rb2D.gravityScale = 0;
        //�ٶ�����Ϊ0
        rb2D.velocity = Vector2.zero;
    }

    //����ͬһ��ײ����Χ���ɿ����ʱ
    private void OnMouseUpAsButton()
    {
        //�ָ�������ƻ����Ӱ��
        rb2D.gravityScale = 3;
    }
}
