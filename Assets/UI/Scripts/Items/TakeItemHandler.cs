using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItemHandler : MonoBehaviour
{
    [SerializeField]
    private bool m_isCollidingPlayer;

    private GameplayManager m_gameplayManager;

    private Collider m_collider;

    private void Start()
    {
        m_gameplayManager = GetComponentInParent<GameplayManager>();
    }

    public bool IsCollidingPlayer
    {
        get { return m_isCollidingPlayer; }
    }

    private void OnTriggerEnter(Collider collider)
    {
        m_isCollidingPlayer = (collider.CompareTag("Player")) ? true : false;
        m_collider = collider;
    }

    private void OnTriggerStay(Collider collider)
    {
        m_isCollidingPlayer = (collider.CompareTag("Player")) ? true : false;
        m_collider = collider;
    }

    private void OnTriggerExit(Collider collider)
    {
        m_isCollidingPlayer = false;
        m_collider = collider;
    }

    public void ActionHandler()
    {
        if (gameObject.CompareTag("Objective"))

            m_gameplayManager.CounterGameplayManager.AddObjective();

        m_collider.GetComponent<ColliderDetector>().Reset();
        Destroy(gameObject);
    }
}
