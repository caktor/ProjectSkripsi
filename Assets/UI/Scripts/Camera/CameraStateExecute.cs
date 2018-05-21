using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateExecute : MonoBehaviour, ICameraHandler
{
    [SerializeField]
    private float m_turnSpeed = 4.0f;

    [SerializeField]
    private float m_minYExecute = 0.5f;

    [SerializeField]
    private float m_maxYExecute = 6.5f;

    private float m_heightExecute = 1f;
    private float m_distanceExecute = 2f;

    private Vector3 m_offsetXExecute;
    private Vector3 m_offsetYExecute;

    private Vector3 m_targetPosition;

    private bool m_isDraging;

    private CameraManager m_cameraManager;


    private void Start()
    {
        m_offsetXExecute = new Vector3(0, m_heightExecute, m_distanceExecute);
        m_offsetYExecute = new Vector3(0, m_heightExecute, m_distanceExecute);
        m_targetPosition = transform.position;

        m_cameraManager = GetComponent<CameraManager>();
    }

    public void UpdateHandler()
    {
        m_offsetXExecute = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_turnSpeed, Vector3.up) * m_offsetXExecute;
        m_offsetYExecute = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * m_turnSpeed, Vector3.left) * m_offsetYExecute;

        m_targetPosition = m_cameraManager.Target.position + m_offsetXExecute + m_offsetYExecute;

        m_targetPosition.y = Mathf.Clamp(m_targetPosition.y, m_minYExecute, m_maxYExecute);
    }

    public void LateUpdateHandler()
    {
        transform.position = m_targetPosition;

        transform.LookAt(m_cameraManager.Target.position);
    }
}
