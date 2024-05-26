using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainPuzzle : MonoBehaviour
{
    [SerializeField] Button[] curtain_button;
    [SerializeField] GameObject[] curtain_obj;

    // 시작시 각 버튼의 onclick에 함수를 입력함.
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
        // 커튼 올라가면 모든 버튼 비활성화 시키고 
        for(int i=0;i<curtain_button.Length;i++)
            curtain_button[i].interactable = false;

        StartCoroutine(Print_Result(index));
    }
    IEnumerator Print_Result(int index)
    {
        // n초 후 결과 출력 
        yield return new WaitForSeconds(1);
        curtain_obj[index].transform.GetChild(1).gameObject.SetActive(true);

        // 게임 오버, 다음 스테이지 이동 결정
        if (index == 0)
            GameSetting.instance.Game_Clear();
        else
            GameSetting.instance.Game_Over();

    }
}