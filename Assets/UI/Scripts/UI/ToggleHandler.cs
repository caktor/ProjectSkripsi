using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    private ControlFlowManager m_controlFlowManager;

    private void Start()
    {
        m_controlFlowManager = GetComponentInParent<ControlFlowManager>();
        GetComponent<Button>().onClick.AddListener(m_controlFlowManager.ToggleWindow);
    }
}
