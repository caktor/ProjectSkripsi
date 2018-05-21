using System;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    private ControlFlowManager m_controlFlowManager;

    private void Start()
    {
        m_controlFlowManager = GetComponentInParent<ControlFlowManager>();

        GetComponent<Button>().onClick.AddListener(OnUp);
    }

    private void OnUp()
    {
        m_controlFlowManager.RemoveCommand(transform.GetSiblingIndex());
    }

}
