using UnityEngine;
using UnityEngine.UI;

public class HeaderHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject play;

    [SerializeField]
    private GameObject clear;

    private CameraManager m_cameraManager;

    private ControlFlowManager m_controlFlowManager;

    private void Start()
    {
        m_controlFlowManager = GetComponentInParent<ControlFlowManager>();
        m_cameraManager = m_controlFlowManager.CameraManager;

        play.GetComponentInChildren<Button>().onClick.AddListener(OnPlayDown);
        clear.GetComponentInChildren<Button>().onClick.AddListener(OnClearDown);
    }

    private void OnClearDown()
    {
        if (m_controlFlowManager.ListCommand.Count == 0)
            return;

        m_controlFlowManager.RemoveCommandAll();
    }

    private void OnPlayDown()
    {
        if (m_controlFlowManager.ListCommand.Count == 0)
            return;

        m_controlFlowManager.ToggleWindow();
        m_cameraManager.ChangeState(CameraManager.CameraState.EXECUTE);

        LeanTween.delayedCall(1.0f, () =>
        {
            m_controlFlowManager.SendToGameplayManager();
        });

    }
}
