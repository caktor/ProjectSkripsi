using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningInfoPanelHandler : MonoBehaviour
{
    [SerializeField]
    private GameplayManager m_gameplayManager;

    [SerializeField]
    private Sprite[] m_spritesContainer = new Sprite[5];

    private Image[] m_imagesChild = new Image[3];

    private GameObject m_container;

    private List<ControlFlowManager.Commands> m_listCommandPlayer = new List<ControlFlowManager.Commands>();

    private int m_counter;

    void Start()
    {
        m_container = transform.GetChild(0).gameObject;

        for (int i = 0; i < m_container.transform.childCount; i++)
            m_imagesChild[i] = m_container.transform.GetChild(i).GetComponent<Image>();

        ResetAllImage();

        m_gameplayManager.OnExecuteStart.AddListener(OnExecuteStart);
        m_gameplayManager.OnExecuteRunning.AddListener(OnExecuteRunning);
        m_gameplayManager.OnExecuteEnd.AddListener(OnExecuteEnd);
    }

    private void OnExecuteStart()
    {
        m_listCommandPlayer = m_gameplayManager.ListCommandPlayer;

        ResetAllImage();

        m_counter = 0;

        m_imagesChild[2].color = SetAlphaColor(m_imagesChild[2].color, 1.0f);
        UpdateSprite(m_imagesChild[2], m_listCommandPlayer[m_counter]);

        Show();
    }

    private void OnExecuteRunning()
    {
        UpdateInfo();
    }

    private void OnExecuteEnd()
    {
        Hide();
    }

    private void ResetAllImage()
    {
        foreach (var image in m_imagesChild)
        {
            Color tempColor = image.color;
            tempColor.a = 0.0f;
            image.color = SetAlphaColor(image.color, 0.0f);
        }
    }

    private void UpdateInfo()
    {
        if (m_counter == 0)
        {
            m_imagesChild[1].color = SetAlphaColor(m_imagesChild[1].color, 1.0f);

            if (m_listCommandPlayer.Count > 1)
                UpdateSprite(m_imagesChild[2], m_listCommandPlayer[m_counter + 1]);

            UpdateSprite(m_imagesChild[1], m_listCommandPlayer[m_counter]);
        }
        if (m_counter == 1)
        {
            m_imagesChild[0].color = SetAlphaColor(m_imagesChild[0].color, 1.0f);

            if (m_listCommandPlayer.Count > 2)
                UpdateSprite(m_imagesChild[2], m_listCommandPlayer[m_counter + 1]);

            UpdateSprite(m_imagesChild[1], m_listCommandPlayer[m_counter]);
            UpdateSprite(m_imagesChild[0], m_listCommandPlayer[m_counter - 1]);
        }
        if (m_counter > 1 && m_counter < (m_listCommandPlayer.Count - 1))
        {

            UpdateSprite(m_imagesChild[2], m_listCommandPlayer[m_counter + 1]);
            UpdateSprite(m_imagesChild[1], m_listCommandPlayer[m_counter]);
            UpdateSprite(m_imagesChild[0], m_listCommandPlayer[m_counter - 1]);
        }
        if (m_counter == (m_listCommandPlayer.Count - 1))
        {
            m_imagesChild[2].color = SetAlphaColor(m_imagesChild[2].color, 0.0f);

            UpdateSprite(m_imagesChild[1], m_listCommandPlayer[m_counter]);

            if (m_listCommandPlayer.Count > 1)
                UpdateSprite(m_imagesChild[0], m_listCommandPlayer[m_counter - 1]);
        }

        m_counter++;
    }

    private Color SetAlphaColor(Color target, float alpha)
    {
        Color temp = target;
        temp.a = alpha;
        return temp;
    }

    private void UpdateSprite(Image targetImage, ControlFlowManager.Commands command)
    {
        switch (command)
        {
            case ControlFlowManager.Commands.FOWARD:
                targetImage.sprite = m_spritesContainer[0];
                break;
            case ControlFlowManager.Commands.FACING_RIGHT:
                targetImage.sprite = m_spritesContainer[1];
                break;
            case ControlFlowManager.Commands.FACING_LEFT:
                targetImage.sprite = m_spritesContainer[2];
                break;
            case ControlFlowManager.Commands.ACTION:
                targetImage.sprite = m_spritesContainer[3];
                break;
            case ControlFlowManager.Commands.PROCEDURE:
                targetImage.sprite = m_spritesContainer[4];
                break;
            case ControlFlowManager.Commands.NULL:
            case ControlFlowManager.Commands.TURN_BACK:
            default:
                break;
        }
    }

    public void Hide()
    {
        LeanTween.cancel(m_container);
        LeanTween
            .moveLocalY(m_container, -75.0f, 0.5f)
            .setEase(LeanTweenType.easeInOutBack);
    }

    public void Show()
    {
        LeanTween.cancel(m_container);
        LeanTween
            .moveLocalY(m_container, 75.0f, 0.5f)
            .setEase(LeanTweenType.easeInOutBack);
    }
}
