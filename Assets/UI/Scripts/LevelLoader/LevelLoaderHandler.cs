using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderHandler : MonoBehaviour
{
    [SerializeField]
    private Text m_textStatus;

    private float m_progress;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            LoadLevel(1);
        if (Input.GetKeyUp(KeyCode.Alpha2))
            LoadLevel(2);
        if (Input.GetKeyUp(KeyCode.Alpha3))
            LoadLevel(3);
        if (Input.GetKeyUp(KeyCode.Alpha4))
            LoadLevel(4);
        if (Input.GetKeyUp(KeyCode.Alpha5))
            LoadLevel(5);
        if (Input.GetKeyUp(KeyCode.Alpha6))
            LoadLevel(6);
        if (Input.GetKeyUp(KeyCode.Alpha7))
            LoadLevel(7);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            m_progress = Mathf.Clamp01(operation.progress / 0.9f);
            m_textStatus.text = (m_progress * 100) + " %";
            yield return null;
        }
    }
}
