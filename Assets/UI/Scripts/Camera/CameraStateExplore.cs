using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateExplore : MonoBehaviour, ICameraHandler
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float m_lerpRate = 0.4f;

    [SerializeField]
    private float m_moveSpeed = 5.0f;

    [SerializeField]
    private Vector3 m_initPosition = Vector3.zero;

    private float m_totalRun = 1.0f;

    private float m_xMovement;

    private float m_yMovement;

    private float m_xRotation;

    private float m_yRotation;

    private Vector3 m_direction;

    private CameraManager m_cameraManager;

    private void Start()
    {
        m_cameraManager = GetComponent<CameraManager>();

        m_initPosition = transform.position;
    }

    public void UpdateHandler()
    {
        if (Input.GetMouseButton(0))
        {
            m_xRotation += Input.GetAxis("Mouse X");
            m_yRotation += Input.GetAxis("Mouse Y");
        }

        m_xRotation = Mathf.Lerp(m_xRotation, 0.0f, m_lerpRate);
        m_yRotation = Mathf.Lerp(m_yRotation, 0.0f, m_lerpRate);

        m_totalRun = Mathf.Clamp(m_totalRun * 0.5f, 1.0f, 1000.0f);

        m_direction = GetDirection();
        m_direction = m_direction * Time.deltaTime * m_moveSpeed;

    }

    private Vector3 GetDirection()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
            velocity += new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.S))
            velocity += new Vector3(0, 0, -1);

        if (Input.GetKey(KeyCode.A))
            velocity += new Vector3(-1, 0, 0);

        if (Input.GetKey(KeyCode.D))
            velocity += new Vector3(1, 0, 0);

        if (Input.GetKey(KeyCode.E))
            velocity += new Vector3(0, 1, 0);

        if (Input.GetKey(KeyCode.Q))
            velocity += new Vector3(0, -1, 0);

        return velocity;
    }

    public void LateUpdateHandler()
    {
        transform.eulerAngles += new Vector3(-m_yRotation, m_xRotation, 0.0f);

        transform.Translate(m_direction);
    }

    public void Init()
    {
        transform.position = m_initPosition;
        transform.LookAt(Vector3.zero);
        m_cameraManager.SetCameraToPerspective();
    }
}
