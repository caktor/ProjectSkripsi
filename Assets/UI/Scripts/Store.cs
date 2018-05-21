using UnityEngine;

public class Store 
{
    //FOR TESTING
    public static int[] TotalSubLevel = new int[3] { 8,8,8};
    
    public static void SetScore(int Level,int SubLevel, int Score)
    {
        PlayerPrefs.SetInt("score" + Level.ToString() + SubLevel.ToString(), Score);
    }
    public static void SetStar(int Level, int SubLevel, int Star)
    {
        PlayerPrefs.SetInt("star" + Level.ToString() + SubLevel.ToString(), Star);
    }
    public static int GetScore(int Level,int SubLevel)
    {
        return PlayerPrefs.GetInt("score" + Level.ToString() + SubLevel.ToString());
    }
    public static int GetStar(int Level, int SubLevel)
    {
        return PlayerPrefs.GetInt("star" + Level.ToString() + SubLevel.ToString());
    }
    public static bool IsLevelUnlock(int Level)
    {
        return (Store.GetScore(Level - 1, Store.TotalSubLevel[Level - 2]) != 0);   
    }

    public static bool isSubLevelUnlock(int Level,int SubLevel)
    {
        Store.Stage stage = Store.GetUnlockNewStage(false);
        if(stage == null)
        {
            return (PlayerPrefs.HasKey("score" + Level.ToString() + (SubLevel - 1).ToString()) );
        } else
        {
            return (PlayerPrefs.HasKey("score" + Level.ToString() + (SubLevel - 1).ToString()) && stage.SubLevel != SubLevel);
        }
    }
    public static void UnlockNewStage(int Level,int SubLevel)
    {
        PlayerPrefs.SetInt("UnlockNewStageLevel", Level);
        PlayerPrefs.SetInt("UnlockNewStageSubLevel", SubLevel);

    }
    public class Stage
    {
        public int Level;
        public int SubLevel;
    }
    public static Stage GetUnlockNewStage(bool Clear)
    {
        
        if (PlayerPrefs.HasKey("UnlockNewStageLevel"))
        {
            Stage stage = new Stage();
            stage.Level = PlayerPrefs.GetInt("UnlockNewStageLevel");
            stage.SubLevel = PlayerPrefs.GetInt("UnlockNewStageSubLevel");
            if (Clear)
            {
                PlayerPrefs.DeleteKey("UnlockNewStageLevel");
                PlayerPrefs.DeleteKey("UnlockNewStageSubLevel");
            }
            
            return stage;
        } else
        {
            return null;
        }
        
    }
    public static void SubmitScore(int Level, int SubLevel, int Score, int Star)
    {
        if(Store.GetScore(Level , SubLevel) == 0) 
        {
            if(SubLevel < Store.TotalSubLevel[Level])
            {
                Store.UnlockNewStage(Level, SubLevel + 1);

                Store.SetGotoPage("SelectSubLevel");
            } else
            {
                Store.UnlockNewStage(Level+ 1, SubLevel );

                Store.SetGotoPage("SelectLevel");
            }
        } else
        {
            Store.SetGotoPage("SelectSubLevel");
        }
        if(Store.GetScore(Level, SubLevel) < Score)
        {
            Store.SetStar(Level, SubLevel, Star);
            Store.SetScore(Level, SubLevel, Score);
        }
       
        if(Star == 3)
        {
            Store.UnlockAchievement(SubLevel);
        }
        


    }
    public static void SetCurrentSubLevel(int Level,int SubLevel)
    {
        PlayerPrefs.SetInt("CurrentLevel", Level);
        PlayerPrefs.SetInt("CurrentSubLevel", SubLevel);
    }
    public static void SetCurrentLevel(int Level)
    {
        PlayerPrefs.SetInt("CurrentLevel", Level);
    }
    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel");
    }
    public static int GetCurrentSubLevel()
    {
        return PlayerPrefs.GetInt("CurrentSubLevel");
    }
    public static void SetGotoPage(string Page)
    {
        PlayerPrefs.SetString("GotoPage", Page);
    }
    public static string GetGotoPage()
    {
        if (PlayerPrefs.HasKey("GotoPage"))
        {
            string GotoPage = PlayerPrefs.GetString("GotoPage"); 
            PlayerPrefs.DeleteKey("GotoPage");
            return GotoPage;
        } else
        {
            return null;
        }
    }
    public static void UnlockAchievement(int index)
    {
        PlayerPrefs.SetInt("Achievement" + index.ToString(), 1);
    }
    public static bool IsAchievementUnlock(int index)
    {
        if(PlayerPrefs.HasKey("Achievement" + index.ToString()))
        {
            return true;
        } else
        {
            return false;
        }
    }
    public static void SetCharacter(int index,string name)
    {
        PlayerPrefs.SetInt("CharacterIndex", index);
        PlayerPrefs.SetString("CharacterName", name);
    }
    public static int GetCharacter()
    {
        return PlayerPrefs.GetInt("CharacterIndex");
    }
    public static string GetCharacterName()
    {
        return PlayerPrefs.GetString("CharacterName");
    }
    public static string CharacterIndexToName(int index)
    {
        string[] Characters = {"Kula","Kula","Kula","Dicky"};
        return Characters[index];
    }
    public static void UnlockCharacter(int index)
    {
        PlayerPrefs.SetInt("Character" + index, 1);
    } 
    public static bool IsCharacterUnlock(int index)
    {
        if (PlayerPrefs.HasKey("Character" + index.ToString()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static string GetVideoText(int Level)
    {
        return "TES";
    }
    
}
