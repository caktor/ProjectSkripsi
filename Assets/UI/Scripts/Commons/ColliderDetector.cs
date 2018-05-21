using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    [SerializeField]
    private bool m_isColliding;

    private Collider m_colliderObject;

    public bool IsColliding
    {
        get { return m_isColliding; }
    }

    public Collider ColliderObject
    {
        get { return m_colliderObject; }
    }

    private void OnTriggerEnter(Collider collider)
    {
        m_isColliding = true;
        m_colliderObject = collider;
    }

    private void OnTriggerStay(Collider collider)
    {
        m_isColliding = true;
        m_colliderObject = collider;
    }

    private void OnTriggerExit(Collider collider)
    {
        m_isColliding = false;
        m_colliderObject = collider;
    }

    public void Reset()
    {
        m_isColliding = false;
        m_colliderObject = null;
    }
}
