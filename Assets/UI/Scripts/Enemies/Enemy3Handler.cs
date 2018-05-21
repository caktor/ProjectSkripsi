using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Handler : MonoBehaviour
{
    [SerializeField]
    private ControlFlowManager.Commands m_currentCommand = ControlFlowManager.Commands.NULL;

    [SerializeField]
    private int m_counter = 0;
    
    [SerializeField]
    private ColliderDetector m_colliderPath;

    [SerializeField]
    private List<ControlFlowManager.Commands> m_listCommand = new List<ControlFlowManager.Commands>();

    private GameplayManager m_gameplayManager;
    private MovementControlFlow m_movementControlFlow;

    //private MovementDetector m_movementDetector;

    private void Start()
    {
        m_gameplayManager = GetComponentInParent<GameplayManager>();
        m_movementControlFlow = GetComponent<MovementControlFlow>();
        //m_movementDetector = GetComponent<MovementDetector>();

        m_gameplayManager.ApplySystemBehaviour.AddListener(Apply);
    }

    private void Apply()
    {
        m_currentCommand = m_listCommand[m_counter];

        switch (m_listCommand[m_counter])
        {
            case ControlFlowManager.Commands.FOWARD:
                //m_movementControlFlow.FowardHandler(m_movementDetector.IsCollidingPath);
                m_movementControlFlow.FowardHandler(m_colliderPath.IsColliding);
                break;
            case ControlFlowManager.Commands.FACING_RIGHT:
                m_movementControlFlow.FacingRightHandler();
                break;
            case ControlFlowManager.Commands.FACING_LEFT:
                m_movementControlFlow.FacingLefthandler();
                break;
            case ControlFlowManager.Commands.TURN_BACK:
                m_movementControlFlow.TurnBackHandler();
                break;
            case ControlFlowManager.Commands.ACTION:
                break;
            case ControlFlowManager.Commands.PROCEDURE:
                break;
            case ControlFlowManager.Commands.NULL:
            default:
                break;
        }

        m_counter = (m_counter == m_listCommand.Count - 1) ? 0 : (m_counter + 1);
    }
}
