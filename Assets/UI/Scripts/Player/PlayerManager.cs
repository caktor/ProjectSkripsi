using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ColliderDetector m_colliderPath;

    [SerializeField]
    private ColliderDetector m_colliderNode;

    [SerializeField]
    private ColliderDetector m_colliderTakeItem;

    private MovementControlFlow m_movementControlFlow;

    private void Start()
    {
        m_movementControlFlow = GetComponent<MovementControlFlow>();
    }

    public void Apply(ControlFlowManager.Commands command)
    {
        switch (command)
        {
            case ControlFlowManager.Commands.FOWARD:
                m_movementControlFlow.FowardHandler(m_colliderPath.IsColliding);
                break;
            case ControlFlowManager.Commands.FACING_RIGHT:
                m_movementControlFlow.FacingRightHandler();
                break;
            case ControlFlowManager.Commands.FACING_LEFT:
                m_movementControlFlow.FacingLefthandler();
                break;
            case ControlFlowManager.Commands.ACTION:
                PlayerActionHandler();
                break;
            case ControlFlowManager.Commands.PROCEDURE:
                break;
            case ControlFlowManager.Commands.NULL:
            default:
                break;
        }

    }

    private void PlayerActionHandler()
    {
        if (m_colliderTakeItem.IsColliding)
            m_colliderTakeItem.ColliderObject.GetComponent<TakeItemHandler>().ActionHandler();

        if (m_colliderNode.IsColliding)
        {
            if (m_colliderNode.ColliderObject.GetComponent<NodeHandler>().IsFinisihNode())
                Debug.Log("Reach Finisih Node");
            else
                Debug.Log("Its just Node");
        }
    }
}
