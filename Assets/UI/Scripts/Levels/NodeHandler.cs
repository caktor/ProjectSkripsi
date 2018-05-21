using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHandler : MonoBehaviour
{
    public enum Type
    {
        IDLE,
        START,
        FINISH
    }

    [SerializeField]
    private Type m_typeNode = Type.IDLE;

    [SerializeField]
    private Material[] m_materials = new Material[3];

    private GameplayManager m_gameplayManager;

    public Type TypeNode
    {
        get { return m_typeNode; }
    }

    private void Start()
    {
        m_gameplayManager = GetComponentInParent<GameplayManager>();

        UpdateByType();
    }

    private void UpdateByType()
    {
        switch (m_typeNode)
        {
            case Type.START:
                GetComponentInChildren<MeshRenderer>().material = m_materials[0];
                break;
            case Type.FINISH:
                GetComponentInChildren<MeshRenderer>().material = m_materials[1];
                break;
            case Type.IDLE:
            default:
                GetComponentInChildren<MeshRenderer>().material = m_materials[2];
                break;
        }
    }

    public bool IsFinisihNode()
    {
        return (m_typeNode == Type.FINISH) ? true : false;
    }
}
