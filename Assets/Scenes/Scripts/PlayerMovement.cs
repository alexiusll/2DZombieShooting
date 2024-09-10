using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 需要引入 InputSystem 库

public class PlayerMovement : MonoBehaviour
{
    // 这是一个属性特性，在 Unity 中使用它可以让私有变量在 Unity 编辑器中显示为可编辑的字段。
    // 这意味着，即使 speed 是私有的，它也可以在 Unity 编辑器的 Inspector 窗口中显示并编辑。
    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    // 加载脚本示例的时候调用
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    // 用于物理运动，固定帧调用
    private void FixedUpdate()
    {
        // 方法一 velocity
        // 需要设置 linear drag 摩擦力, 否则玩家不会停下来
        // 但是这种方式可能不够线性,因为玩家一开始被施加很大的速度
        //if (movement.x != 0 || movement.y != 0)
        //{
        //    // 刚体的 线性速度
        //    rb.velocity = movement * speed;
        //}

        // 方法二 MovePosition ,可能不够物理?
        // Time.fixedDeltaTime 的值就等于 0.02
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        // Debug.Log("FixedDeltaTime: " + Time.fixedDeltaTime);

        // 方法三 施加一个力
        // rb.AddForce(movement * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 什么也不做
    }

    // Update is called once per frame
    void Update()
    {
        // 什么也不做
    }
}
