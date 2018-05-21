using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingInGameManager : MonoBehaviour
{
    [SerializeField]
    private float m_speedShowHide = 0.5f;

    [SerializeField]
    private LeanTweenType m_tweenType = LeanTweenType.easeOutBounce;

    [SerializeField]
    private ControlFlowManager m_controlFlowManager;

    [SerializeField]
    private GameObject m_backgroundPanel;

    [SerializeField]
    private GameObject m_panel;

    private bool m_isSettingPanelShow;

    private void ClearTween()
    {
        LeanTween.cancel(m_panel);
        LeanTween.cancel(m_backgroundPanel);
    }

    public bool IsSettingPanelShow
    {
        get { return m_isSettingPanelShow; }
    }

    public void ShowHideSettingPanel()
    {

        ClearTween();

        if (m_isSettingPanelShow)
            HideSettingPanel();
        else
            ShowSettingPanel();
    }

    public void HideSettingPanel()
    {
        LeanTween
            .rotate(m_panel, Vector3.forward * -90.0f, m_speedShowHide)
            .setEase(m_tweenType);

        LeanTween
            .alpha(m_backgroundPanel.GetComponent<RectTransform>(), 0.0f, m_speedShowHide)
            .setOnComplete(()=> { m_backgroundPanel.SetActive(false); })
            .setEase(m_tweenType);

        m_isSettingPanelShow = false;
    }

    public void ShowSettingPanel()
    {
        m_controlFlowManager.PanelOnHide();

        LeanTween
            .rotate(m_panel, Vector3.zero, m_speedShowHide)
            .setEase(m_tweenType);

        LeanTween
            .alpha(m_backgroundPanel.GetComponent<RectTransform>(), 0.7f, m_speedShowHide)
            .setOnStart(()=> { m_backgroundPanel.SetActive(true); })
            .setEase(m_tweenType);

        Debug.Log(m_backgroundPanel.name);

        m_isSettingPanelShow = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
