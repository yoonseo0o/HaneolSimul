using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainPuzzle : MonoBehaviour
{
    [SerializeField] private Button[] curtain_button;
    
    curtain_color color;
    public enum curtain_color
    {
        blue,
        red
    }

    private enum curtain_state
    {
        open,
        close,
        result
    }

    // 시작시 각 버튼의 onclick에 함수를 입력함.
    private void Awake()
    {
        for (int i = 0; i < curtain_button.Length; i++)
        {
            int index = i;
            curtain_button[i].onClick.AddListener(() => OnClick((curtain_color)index));
        }
    }
    public void OnClick(curtain_color color)
    {
        for(int i=0;i<curtain_button.Length;i++)
            curtain_button[i].interactable = false;

        curtain_button[(int)color].transform.GetChild((int)curtain_state.close).gameObject.SetActive(true);
        StartCoroutine(Print_Result(color, 1));
    }
    IEnumerator Print_Result(curtain_color color, float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        curtain_button[(int)color].transform.GetChild((int)curtain_state.result).gameObject.SetActive(true);

        switch (color)
        {
            case curtain_color.blue:
                GameSetting.instance.Game_Clear();
                break;

            case curtain_color.red:
                GameSetting.instance.Game_Over();
                break;
        }
    }
}