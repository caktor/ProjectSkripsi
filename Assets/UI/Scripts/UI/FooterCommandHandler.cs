using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterCommandHandler : MonoBehaviour
{
    private ControlFlowManager m_controlFlowManager;
    private FooterHandler m_footerHandler;

    private void Start()
    {
        m_controlFlowManager = GetComponentInParent<ControlFlowManager>();
        m_footerHandler = GetComponentInParent<FooterHandler>();

        GetComponent<Button>().onClick.AddListener(OnUp);
    }

    private void OnUp()
    {
        m_controlFlowManager.AddCommand(gameObject.name);
    }

}
