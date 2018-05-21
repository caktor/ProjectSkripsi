using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlowManager : MonoBehaviour
{
    public enum Commands
    {
        FOWARD,
        FACING_RIGHT,
        FACING_LEFT,
        TURN_BACK,
        ACTION,
        PROCEDURE,
        NULL
    }

    [SerializeField]
    private GameplayManager m_gameplayManager;

    [SerializeField]
    private CameraManager m_cameraManager;

    [SerializeField]
    private SettingInGameManager m_settingInGameManager;

    [SerializeField]
    private float[] m_hideShowValue = new float[2];

    private List<Commands> m_listCommand = new List<Commands>();

    private GameObject m_headerUI;

    private ContentHandler m_contentUI;
    private RectTransform m_rectTransform;

    private float m_widthRect;
    private bool m_isShow;

    public List<Commands> ListCommand
    {
        get { return m_listCommand; }
    }

    internal CameraManager CameraManager
    {
        get { return m_cameraManager; }
    }

    private void Start()
    {
        m_contentUI = GetComponentInChildren<ContentHandler>();
        m_rectTransform = GetComponent<RectTransform>();

        m_widthRect = m_rectTransform.rect.width;
    }

    internal void SendToGameplayManager()
    {
        m_gameplayManager.AddCommand(m_listCommand);
    }

    internal void RemoveCommandAll()
    {
        m_listCommand = new List<Commands>();
        m_contentUI.RemoveAll();
    }

    public void AddCommand(string commandName)
    {
        Commands command = StringToCommand(commandName);

        m_contentUI.AddCommand(commandName);
        m_listCommand.Add(command);
    }

    public void RemoveCommand(int index)
    {
        m_contentUI.Remove(index);
        m_listCommand.RemoveAt(index);
    }

    public void ToggleWindow()
    {
        LeanTween.cancel(gameObject);

        //if (m_cameraManager.State == CameraManager.CameraState.EXECUTE)

        if (m_isShow)
            PanelOnHide();
        else
            PanelOnShow();
    }

    public void PanelOnHide()
    {
        m_cameraManager.ChangeState(CameraManager.CameraState.EXPLORE);

        LeanTween
            .moveLocalX(gameObject, (m_widthRect * m_hideShowValue[0]), 0.5f)
            .setEase(LeanTweenType.easeInOutBack);

        m_isShow = false;
    }

    public void PanelOnShow()
    {
        m_settingInGameManager.HideSettingPanel();

        m_cameraManager.ChangeState(CameraManager.CameraState.DESIGN);

        LeanTween
            .moveLocalX(gameObject, (m_widthRect / m_hideShowValue[1]), 0.5f)
            .setEase(LeanTweenType.easeInOutBack);

        m_isShow = true;
    }

    public Commands StringToCommand(string commandName)
    {
        switch (commandName)
        {
            case "Foward":
                return Commands.FOWARD;
            case "FacingRight":
                return Commands.FACING_RIGHT;
            case "FacingLeft":
                return Commands.FACING_LEFT;
            case "Action":
                return Commands.ACTION;
            case "Procedure":
                return Commands.PROCEDURE;
            default:
                return Commands.NULL;
        }
    }

    public string CommandToUIString(string commandName)
    {
        switch (commandName)
        {
            case "Foward":
                return "MAJU";
            case "FacingRight":
                return "H. KANAN";
            case "FacingLeft":
                return "H. KIRI";
            case "Action":
                return "AKSI";
            case "Procedure":
                return "PROSEDUR";
            default:
                return "NULL";
        }
    }
}
