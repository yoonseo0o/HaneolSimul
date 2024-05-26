using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainPuzzle : MonoBehaviour
{
    [SerializeField] Button[] curtain_button;
    [SerializeField] GameObject[] curtain_obj;

    // ���۽� �� ��ư�� onclick�� �Լ��� �Է���.
    private void Awake()
    {
        for (int i = 0; i < curtain_button.Length; i++)
        {
            int index = i;
            curtain_button[i].onClick.AddListener(() => OnClick(index));
        }
    }
    public void OnClick(int index)
    {
        // Ŀư �ö󰡸� ��� ��ư ��Ȱ��ȭ ��Ű�� 
        for(int i=0;i<curtain_button.Length;i++)
            curtain_button[i].interactable = false;

        StartCoroutine(Print_Result(index));
    }
    IEnumerator Print_Result(int index)
    {
        // n�� �� ��� ��� 
        yield return new WaitForSeconds(1);
        curtain_obj[index].transform.GetChild(1).gameObject.SetActive(true);

        // ���� ����, ���� �������� �̵� ����
        if (index == 0)
            GameSetting.instance.Game_Clear();
        else
            GameSetting.instance.Game_Over();

    }
}