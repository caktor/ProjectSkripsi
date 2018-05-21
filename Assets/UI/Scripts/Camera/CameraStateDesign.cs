using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class CameraStateDesign : MonoBehaviour, ICameraHandler
{
    [SerializeField]
    private float m_speedTransition = 1.0f;

    [SerializeField]
    private float m_sensitivity = 5.0f;

    [SerializeField]
    private Vector3 m_targetPosition = Vector3.zero;

    [SerializeField]
    private float[] m_boundsHeight = new float[2];

    [SerializeField]
    private float[] m_boundsWidth = new float[2];

    [SerializeField]
    private float[] m_boundsZoom = new float[2];

    private CameraManager m_cameraManager;

    private Vector3 m_lastPosition;

    private int m_fingerId;

    private bool m_wasZoomingLastFrame;

    private Vector2[] m_lastZoomPositions;

    private void Start()
    {
        m_cameraManager = GetComponent<CameraManager>();
    }

    public void Init()
    {
        LeanTween.cancel(gameObject);
        LeanTween.
            rotate(gameObject, Vector3.right * 90.0f, 0.5f);
        m_cameraManager.SetCameraToOrthographic();
    }

    public void UpdateHandler()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
            m_lastPosition = Input.mousePosition;
        else if (Input.GetMouseButton(0))
            PanCamera(Input.mousePosition);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, m_speedTransition);
    }

    public void LateUpdateHandler()
    {
        //transform.position = Vector3.Lerp(transform.position, m_targetPosition, m_speedTransition * Time.deltaTime);
        transform.position = m_targetPosition;
    }

    private void PanCamera(Vector3 targetPosition)
    {
        Vector3 offset = m_cameraManager.Camera.ScreenToViewportPoint(m_lastPosition - targetPosition);
        m_targetPosition += new Vector3(offset.x * m_sensitivity, 0.0f, offset.y * m_sensitivity);

        m_targetPosition.x = Mathf.Clamp(m_targetPosition.x, m_boundsHeight[0], m_boundsHeight[1]);
        m_targetPosition.z = Mathf.Clamp(m_targetPosition.z, m_boundsWidth[0], m_boundsWidth[1]);

        m_lastPosition = targetPosition;
    }

    private void ZoomCamera(float offset, float speed)
    {
        if (offset == 0)
            return;

        m_cameraManager.Camera.orthographicSize = Mathf.Clamp(m_cameraManager.Camera.orthographicSize - (offset * speed), m_boundsZoom[0], m_boundsZoom[1]);
    }
}
