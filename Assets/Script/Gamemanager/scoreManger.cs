using UnityEngine;

public class scoreManger : MonoBehaviour
{
    public static scoreManger Instance;

    string dataPate = "hightScoreLevel";

    private void Awake()
    {
        Instance = this;
    }

    public void levelComplete(int level, int score)
    {
        if (score <= PlayerPrefs.GetInt(getLevelPath(level), 0))
            return;

        PlayerPrefs.SetInt(getLevelPath(level), score);
    }

    public int getScore(int level)
    {
        return PlayerPrefs.GetInt(getLevelPath(level), 0);
    }

    public void resetScore()
    {
        PlayerPrefs.DeleteAll();
    }

    string getLevelPath(int level)
    {
        return dataPate + level;
    }
}
