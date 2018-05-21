using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public int SubLevel;
    public Sprite AchievementSprite;
    public Sprite AchievementPhotoSprite;
    private Achievement m_achievement;
    private Dialog m_dialog;
    private AchievementDialog m_achievementDialog;
    
    

    // Use this for initialization
    void Start()
    {
        m_achievement = gameObject.GetComponentInParent<Achievement>();
        m_dialog = m_achievement.AchievementDialog.GetComponent<Dialog>();
        m_achievementDialog = m_achievement.AchievementDialog.GetComponent<AchievementDialog>();
        if (Store.IsAchievementUnlock(SubLevel))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AchievementSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Store.IsAchievementUnlock(SubLevel))
        {
            m_achievementDialog.SetContent(AchievementPhotoSprite, m_achievement.AchievementData[SubLevel - 1].description);
            m_dialog.Show();

        }
    }
}
