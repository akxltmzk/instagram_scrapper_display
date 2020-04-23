﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    #region Variable

    [Header("UI")]
    public GameObject UICanvas;
    public GameObject[] UIObject_Array;

    [Header("UI Position")]
    public Transform UIPosition_leader;

    [Header("Start Target")]
    public GameObject start_target;
    public Text start_target_txt;

    // private
    private float gazing_timer;
    private bool isDebug;

    #endregion

    #region Standard Function

    private void Start()
    {
        isDebug = AppManager.Instance.isDebug;
        gazing_timer = AppManager.Instance.gazing_time;

        if (isDebug)
            UICanvas.SetActive(false);
    }

    private void Update()
    {
        if(!isDebug)
            UICanvas_Position_Set();
    }

    #endregion

    #region Gazing Function
    
    public void gazing_up() {       
        gazing_timer -= Time.deltaTime;
        int time = (int)(gazing_timer % 60);
        start_target_txt.text = time.ToString();

        if (gazing_timer < 0)
        {        
            UICanvas.SetActive(false);
            start_target.SetActive(false);
            gazing_timer = AppManager.Instance.gazing_time;
            SocketManager.Instance.UserReady();
            InitScene.Instance.experience_on = !InitScene.Instance.experience_on;
            InitScene.Instance.ManageExperience();
        }
    }

    public void gazing_down() {
        start_target_txt.text = "START";
        gazing_timer = AppManager.Instance.gazing_time;
    }

    #endregion

    #region UI Function

    private void UICanvas_Position_Set() {
        UICanvas.transform.position = Vector3.Lerp(UICanvas.transform.position, UIPosition_leader.position, Time.deltaTime * 2);
        UICanvas.transform.rotation = Quaternion.Lerp(UICanvas.transform.rotation, UIPosition_leader.rotation, Time.deltaTime);
    }

    #endregion
}
