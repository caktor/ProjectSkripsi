using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsHandler : MonoBehaviour
{
    private GameplayManager m_gameplayManager;

    private void Start()
    {
        m_gameplayManager = GetComponentInParent<GameplayManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            m_gameplayManager.CounterGameplayManager.AddGem();

            collider.GetComponent<ColliderDetector>().Reset();
            Destroy(gameObject);
        }
    }

}
