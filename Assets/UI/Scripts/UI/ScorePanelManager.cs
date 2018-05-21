using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelManager : MonoBehaviour
{
    private const float INIT_DURATION = 0.0f;

    [SerializeField]
    private GameplayManager m_gameplayManager;

    [Header("Setup Animation")]

    [SerializeField]
    private float m_duration = 1.0f;

    [SerializeField]
    private LeanTweenType m_tweenType = LeanTweenType.easeOutBack;

    [Header("Reference for Intro")]

    [SerializeField]
    private GameObject m_background;

    [SerializeField]
    private GameObject m_backgroundAnimation;

    [SerializeField]
    private GameObject m_header;

    [SerializeField]
    private GameObject m_panelLeft;

    [SerializeField]
    private GameObject m_panelRight;

    [SerializeField]
    private GameObject m_footer;

    [Header("Content")]

    [SerializeField]
    private Text m_commandText;

    [SerializeField]
    private Text m_objectiveText;

    [SerializeField]
    private Text m_gemText;

    [SerializeField]
    private Text m_scoreText;

    [Header("Star")]

    [SerializeField]
    private GameObject star1;

    [SerializeField]
    private GameObject star2;

    [SerializeField]
    private GameObject star3;

    private int m_score;


    private void OnEnable()
    {
        Hide();
        Show1();
    }

    public void Hide()
    {
        LeanTween.moveLocalY(m_background, m_background.transform.localPosition.y + 800.0f, INIT_DURATION);

        LeanTween.scale(m_backgroundAnimation, Vector3.zero, INIT_DURATION);

        LeanTween.moveLocalX(m_panelLeft, -800.0f, INIT_DURATION);

        LeanTween.alpha(star1, 0.0f, INIT_DURATION);
        LeanTween.moveLocalY(star1, 0.0f, INIT_DURATION);

        LeanTween.alpha(star2, 0.0f, INIT_DURATION);
        LeanTween.moveLocalY(star2, 0.0f, INIT_DURATION);

        LeanTween.alpha(star3, 0.0f, INIT_DURATION);
        LeanTween.moveLocalY(star3, 0.0f, INIT_DURATION);

        LeanTween.moveLocalX(m_panelRight, 800.0f, INIT_DURATION);

        LeanTween.moveLocalY(m_footer, -150.0f, INIT_DURATION);
    }

    public void Show1()
    {
        LeanTween
            .moveLocalY(m_background, 0.0f, m_duration)
            .setEase(m_tweenType);

        LeanTween
            .scale(m_backgroundAnimation, Vector3.one * 0.85f, m_duration)
            .setDelay(0.5f)
            .setEase(m_tweenType);

        LeanTween
            .moveLocalX(m_panelLeft, -192.0f, m_duration)
            .setDelay(1.0f)
            .setEase(m_tweenType)
            .setOnComplete(Show2);

    }

    private void Show2()
    {
        int command = m_gameplayManager.CounterGameplayManager.Command;
        int objective = m_gameplayManager.CounterGameplayManager.Objective;
        int gem = m_gameplayManager.CounterGameplayManager.Gem;

        LeanTween
            .value(gameObject, 0.0f, command, 0.3f)
            .setOnUpdate((float res) =>
            {
                m_commandText.text = ((int)(res)).ToString();
            });

        LeanTween
            .value(gameObject, 0.0f, objective, 0.3f)
            .setDelay(0.3f)
            .setOnUpdate((float res) =>
            {
                m_objectiveText.text = ((int)(res)).ToString();
            });

        LeanTween
            .value(gameObject, 0.0f, gem, 0.3f)
            .setDelay(0.6f)
            .setOnUpdate((float res) =>
            {
                m_gemText.text = ((int)(res)).ToString();
            })
            .setOnComplete(Show3);
    }

    public void Show3()
    {
        LeanTween
            .moveLocalX(m_panelRight, 128.0f, m_duration)
            .setEase(m_tweenType);

        m_score = m_gameplayManager.LevelSetting.GetScore(m_gameplayManager.CounterGameplayManager);
        int statusScore = m_gameplayManager.LevelSetting.GetStatus(m_score);

        switch (statusScore)
        {
            case 2:
                MoveStarToY(star1, 90.0f);
                MoveStarToY(star2, 110, 0.3f);
                MoveStarToY(star3, 90, 0.6f);
                LeanTween.delayedCall(0.9f, Show4);
                break;
            case 1:
                MoveStarToY(star1, 90.0f);
                MoveStarToY(star2, 110, 0.3f);
                LeanTween.delayedCall(0.6f, Show4);
                break;
            case 0:
                MoveStarToY(star1, 90.0f);
                LeanTween.delayedCall(0.3f, Show4);
                break;
            default:
                break;
        }
    }

    public void Show4()
    {
        LeanTween
            .moveLocalY(m_footer, 0.0f, m_duration)
            .setEase(m_tweenType);
        LeanTween
            .value(0.0f, m_score, m_duration)
            .setDelay(0.3f)
            .setOnUpdate((float res) =>
            {
                m_scoreText.text = "SCORE : " + ((int)(res)).ToString();
            });
    }

    private void MoveStarToY(GameObject star, float target, float delay = 0.0f)
    {
        LeanTween
            .moveLocalY(star, target, m_duration)
            .setDelay(delay)
            .setEase(m_tweenType);
    }
}
