using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public enum CameraState
    {
        INIT,
        EXPLORE,
        DESIGN,
        EXECUTE
    }

    [SerializeField]
    private CameraState m_cameraState = CameraState.INIT;

    [SerializeField]
    private Transform m_target;

    private CameraStateExplore m_cameraStateExplore;
    private CameraStateDesign m_cameraStateDesign;
    private CameraStateExecute m_cameraStateExecute;

    private Camera m_camera;

    public Transform Target
    {
        get { return m_target; }
    }

    public Camera Camera
    {
        get { return m_camera; }
    }

    public CameraState State
    {
        get { return m_cameraState; }
    }

    private void Start()
    {
        m_cameraStateExplore = GetComponent<CameraStateExplore>();
        m_cameraStateDesign = GetComponent<CameraStateDesign>();
        m_cameraStateExecute = GetComponent<CameraStateExecute>();

        m_camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
            m_cameraState = CameraState.INIT;

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            m_cameraState = CameraState.EXPLORE;
            SetCameraToPerspective();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            m_cameraState = CameraState.DESIGN;
            m_cameraStateDesign.Init();
            SetCameraToOrthographic();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            m_cameraState = CameraState.EXECUTE;
            SetCameraToPerspective();
        }

        switch (m_cameraState)
        {
            case CameraState.EXPLORE:
                m_cameraStateExplore.UpdateHandler();
                break;
            case CameraState.DESIGN:
                m_cameraStateDesign.UpdateHandler();
                break;
            case CameraState.EXECUTE:
                m_cameraStateExecute.UpdateHandler();
                break;
            case CameraState.INIT:
            default:
                break;
        }
    }

    private void LateUpdate()
    {

        switch (m_cameraState)
        {
            case CameraState.EXPLORE:
                m_cameraStateExplore.LateUpdateHandler();
                break;
            case CameraState.DESIGN:
                m_cameraStateDesign.LateUpdateHandler();
                break;
            case CameraState.EXECUTE:
                m_cameraStateExecute.LateUpdateHandler();
                break;
            case CameraState.INIT:
            default:
                break;
        }
    }

    public void ChangeState(CameraState cameraState)
    {
        m_cameraState = cameraState;

        switch (m_cameraState)
        {
            case CameraState.EXPLORE:
                m_cameraStateExplore.Init();
                break;
            case CameraState.DESIGN:
                m_cameraStateDesign.Init();
                break;
            case CameraState.EXECUTE:
                break;
            case CameraState.INIT:
            default:
                break;
        }

    }

    public void SetCameraToOrthographic()
    {
        m_camera.orthographic = true;
    }

    public void SetCameraToPerspective()
    {
        m_camera.orthographic = false;
    }
}
