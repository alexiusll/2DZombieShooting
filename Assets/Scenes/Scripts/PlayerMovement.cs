using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // ��Ҫ���� InputSystem ��

public class PlayerMovement : MonoBehaviour
{
    // ����һ���������ԣ��� Unity ��ʹ����������˽�б����� Unity �༭������ʾΪ�ɱ༭���ֶΡ�
    // ����ζ�ţ���ʹ speed ��˽�еģ���Ҳ������ Unity �༭���� Inspector ��������ʾ���༭��
    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    // ���ؽű�ʾ����ʱ�����
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

    // ���������˶����̶�֡����
    private void FixedUpdate()
    {
        // ����һ velocity
        // ��Ҫ���� linear drag Ħ����, ������Ҳ���ͣ����
        // �������ַ�ʽ���ܲ�������,��Ϊ���һ��ʼ��ʩ�Ӻܴ���ٶ�
        //if (movement.x != 0 || movement.y != 0)
        //{
        //    // ����� �����ٶ�
        //    rb.velocity = movement * speed;
        //}

        // ������ MovePosition ,���ܲ�������?
        // Time.fixedDeltaTime ��ֵ�͵��� 0.02
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        // Debug.Log("FixedDeltaTime: " + Time.fixedDeltaTime);

        // ������ ʩ��һ����
        // rb.AddForce(movement * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        // ʲôҲ����
    }

    // Update is called once per frame
    void Update()
    {
        // ʲôҲ����
    }
}
