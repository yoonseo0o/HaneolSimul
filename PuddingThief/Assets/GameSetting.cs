using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    [SerializeField] private GameObject game_over_ui;
    [SerializeField] private GameObject game_clear_ui;
    [SerializeField] private GameObject game_setting_ui;
    public static GameSetting instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void Game_Clear()
    {
        game_clear_ui.SetActive(true);
    }

    public void Game_Setting()
    {
        game_setting_ui.SetActive(true);
    }

    public void Game_Over()
    {
        game_over_ui.SetActive(true);
    }

}