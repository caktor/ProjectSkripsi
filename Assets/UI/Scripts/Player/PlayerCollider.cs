using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private bool m_isColliding;

    private void OnTriggerEnter(Collider collider)
    {
        m_isColliding = true;
    }

    private void OnTriggerStay(Collider collider)
    {
        m_isColliding = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        m_isColliding = false;
    }

}
