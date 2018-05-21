using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FooterCommandDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool m_isDrag;
    private Vector3 prevPosition;
    private int currentIndex;

    private void Start()
    {
        currentIndex = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_isDrag = true;
        prevPosition = transform.position;

        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_isDrag = false;
        transform.position = prevPosition;

        transform.SetSiblingIndex(currentIndex);
    }
}
