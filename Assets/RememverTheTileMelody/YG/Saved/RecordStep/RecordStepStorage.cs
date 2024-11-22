using UnityEngine;
using YG;

public class RecordStepStorage : IRecordStepStorage
{
    public int GetValue()
    {
        int score = YandexGame.savesData._bestScore;
        return score;
    }

    public int SetValue(int value)
    {
        YandexGame.savesData._bestScore = value;
        YandexGame.SaveProgress();
        Debug.Log($"SetValue called: New best score is {value}");
        return value;
    }
}
