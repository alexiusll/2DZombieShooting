using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject UI;

    private bool canMove = true;

    // ���ؽű�ʾ����ʱ�����
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnOpenMenu(InputValue value)
    {
        UImanager uiManager = UI.GetComponent<UImanager>(); 
        if (!uiManager.menu.activeSelf)
        {
            canMove = false;
            uiManager.OpenMenu();
        }
        else
        {
            canMove = true;
            uiManager.CloseMenu();
        }

    }

    // OnMovement ���������� Player Input ���
    private void OnMovement(InputValue value)
    {
        if (canMove)
        {
            movement = value.Get<Vector2>();

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("moveX", movement.x);
                animator.SetFloat("moveY", movement.y);

                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
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

        // ��������׼��������ˮƽλ�ƺ�б����λ���ٶȲ�ͬ�����⣨�ƺ�����Ͳ������������...)
        Vector2 movementNorm = movement.normalized;

        rb.MovePosition(rb.position + movementNorm * speed * Time.fixedDeltaTime);
        // Time.fixedDeltaTime ��ֵ�͵��� 0.02
        // Debug.Log("FixedDeltaTime: " + Time.fixedDeltaTime);

        // Debug.Log("movementNorm: " + movementNorm.ToString());

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
