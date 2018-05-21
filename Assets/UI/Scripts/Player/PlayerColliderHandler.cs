using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderHandler : MonoBehaviour
{
    private bool m_isColliding;

    public bool IsColliding
    {
        get { return m_isColliding; }
    }

    private void OnTriggerEnter(Collider collider)
    {
        m_isColliding = collider.CompareTag("Path") ? true : false;
    }

    private void OnTriggerStay(Collider collider)
    {
        m_isColliding = collider.CompareTag("Path") ? true : false;
    }

    private void OnTriggerExit(Collider collider)
    {
        m_isColliding = false;
    }
}
