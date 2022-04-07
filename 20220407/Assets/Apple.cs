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
        //获取鼠标位置的世界坐标
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //获取苹果与鼠标的位置差
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    //当在碰撞器范围内按到鼠标时
    private void OnMouseDrag()
    {
        //更新苹果位置
        transform.position = mousePos + distance;
        //消除重力影响
        rb2D.gravityScale = 0;
        //速度设置为0
        rb2D.velocity = Vector2.zero;
    }

    //当在同一碰撞器范围内松开鼠标时
    private void OnMouseUpAsButton()
    {
        //恢复重力对苹果的影响
        rb2D.gravityScale = 3;
    }
}
