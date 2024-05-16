using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlotBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _sName;
    [SerializeField] TextMeshProUGUI _sTime;
    [SerializeField] TextMeshProUGUI _sScore;

    public void SetName(string name)
    {
        _sName.text = name;
    }

    public void SetTime(int time)
    {
        _sTime.text = $"{time} s";
    }

    public void SetScore(int score)
    {
        _sScore.text = score.ToString();
    }
}
