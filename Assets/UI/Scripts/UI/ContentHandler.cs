using System;
using UnityEngine;
using UnityEngine.UI;

public class ContentHandler : MonoBehaviour
{
    [SerializeField]
    private Transform m_containerContent;

    [SerializeField]
    private GameObject[] commandsPrefabs = new GameObject[5];

    private ControlFlowManager m_controlFlowManager;

    private void Start()
    {
        m_controlFlowManager = GetComponentInParent<ControlFlowManager>();
    }

    public void AddCommand(string commandName)
    {
        GameObject commandPrefab = Instantiate(SelectPrefabCoammands(commandName));
        commandPrefab.transform.SetParent(m_containerContent);
        //commandPrefab.GetComponentInChildren<Text>().text = m_controlFlowManager.CommandToUIString(commandName);
        commandPrefab.transform.localScale = Vector3.one;
    }

    private GameObject SelectPrefabCoammands(string commandName)
    {
        switch (commandName)
        {
            case "Foward":
                return commandsPrefabs[0];
            case "FacingRight":
                return commandsPrefabs[1];
            case "FacingLeft":
                return commandsPrefabs[2];
            case "Action":
                return commandsPrefabs[3];
            case "Procedure":
                return commandsPrefabs[4];
            default:
                return null;
        }
    }

    internal void Remove(int index)
    {
        Destroy(m_containerContent.transform.GetChild(index).gameObject);
    }

    internal void RemoveAll()
    {
        foreach (Transform item in m_containerContent.transform)
            Destroy(item.gameObject);
    }
}
