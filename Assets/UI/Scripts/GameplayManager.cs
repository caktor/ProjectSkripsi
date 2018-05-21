using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameplayManager : MonoBehaviour
{

    [SerializeField]
    private LevelSetting m_levelSetting;

    [SerializeField]
    private CounterManager m_counterGameplayManager;

    [SerializeField]
    private float m_duration = 1.0f;

    [SerializeField]
    private List<ControlFlowManager.Commands> m_listCommandPlayer = new List<ControlFlowManager.Commands>();

    private List<ControlFlowManager.Commands> m_listCommandExecute = new List<ControlFlowManager.Commands>();

    private PlayerManager m_playerManager;

    private UnityEvent m_applySystemBehaviour = new UnityEvent();
    private UnityEvent m_onExecuteStart = new UnityEvent();
    private UnityEvent m_onExecuteRunning = new UnityEvent();
    private UnityEvent m_onExecuteEnd = new UnityEvent();

    public static float Duration = 1.0f;

    public UnityEvent ApplySystemBehaviour
    {
        get
        {
            if (m_applySystemBehaviour == null)
                m_applySystemBehaviour = new UnityEvent();

            return m_applySystemBehaviour;
        }
    }
    public UnityEvent OnExecuteStart
    {
        get
        {
            if (m_onExecuteStart == null)
                m_onExecuteStart = new UnityEvent();

            return m_onExecuteStart;
        }
    }
    public UnityEvent OnExecuteRunning
    {
        get { return m_onExecuteRunning; }
    }
    public UnityEvent OnExecuteEnd
    {
        get
        {
            if (m_onExecuteEnd == null)
                m_onExecuteEnd = new UnityEvent();

            return m_onExecuteEnd;
        }
    }

    public List<ControlFlowManager.Commands> ListCommandPlayer
    {
        get { return m_listCommandPlayer; }
    }

    internal LevelSetting LevelSetting
    {
        get { return m_levelSetting; }
    }

    internal CounterManager CounterGameplayManager
    {
        get { return m_counterGameplayManager; }
    }

    private void Start()
    {
        m_playerManager = GetComponentInChildren<PlayerManager>();

        Duration = m_duration;

        m_levelSetting = new LevelSetting();
        m_counterGameplayManager = new CounterManager();
    }

    private IEnumerator Execute()
    {
        int lengthCommand = m_listCommandExecute.Count;

        if (lengthCommand == 0)
        {
            m_onExecuteEnd.Invoke();
            yield break;
        }

        m_onExecuteRunning.Invoke();
        m_playerManager.Apply(m_listCommandExecute[0]);
        m_counterGameplayManager.AddCommand();
        yield return new WaitForSeconds(m_duration);
        m_applySystemBehaviour.Invoke();
        yield return new WaitForSeconds(m_duration);


        if (lengthCommand > 0)
        {
            m_listCommandExecute.RemoveAt(0);
            StartCoroutine(Execute());
        }
    }

    public void AddCommand(List<ControlFlowManager.Commands> listCommand)
    {
        m_listCommandPlayer = listCommand;
        m_listCommandExecute = new List<ControlFlowManager.Commands>(listCommand);


        m_onExecuteStart.Invoke();
        StartCoroutine(Execute());
    }

}

[Serializable]
class CounterManager
{
    public int Command = 0;
    public int Objective = 0;
    public int Gem = 0;

    public CounterManager()
    {
    }

    public void AddCommand()
    {
        Command++;
    }

    public void AddObjective()
    {
        Objective++;
    }

    public void AddGem()
    {
        Gem++;
    }

    public void Reset()
    {
        Command =
            Objective =
            Gem = 0;
    }

    public override string ToString()
    {
        return "CounterManager::Command = " + Command + " | Objective = " + Objective + " | Gem = " + Gem;
    }
}

[Serializable]
class LevelSetting
{
    public int BestCommand = 0;

    public int Score = 0;

    public int MinScore = 0;
    public int MidScore = 0;
    public int MaxScore = 0;

    public LevelSetting()
    {

    }

    public int GetScore(CounterManager counterManager)
    {
        //(100 * 10) - ((10 - 10) * 50) * -1

        int command = (100 * BestCommand) - ((BestCommand - counterManager.Command) * 50) * -1;
        int objective = counterManager.Objective * 200;
        int gem = counterManager.Gem * 50;

        Score = command + objective + gem;

        return Score;
    }

    public int GetStatus(int score)
    {
        if (score >= MaxScore)
            return 2;

        if (score >= MidScore && score < MaxScore)
            return 1;

        if (score >= MinScore && score < MidScore)
            return 0;

        return -1;
    }
}

