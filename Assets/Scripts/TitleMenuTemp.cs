using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleMenuTemp : MonoBehaviour
{
    public GameObject pressStart;

    public string newGameScene;

    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0�������
        {

            Debug.Log("�����������");

            // ����д��ĵ���߼�
            pressStart.SetActive(false);
            ShowMenu();
        }
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("����˳���Ϸ");

        Application.Quit();
    }

    public void NewGame(int difficulty)
    {
        Debug.Log("�����ʼ��Ϸ����Ϸ�Ѷ�:" + difficulty);

        SceneManager.LoadScene(newGameScene);

    }
}
