using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests 
{
    public bool isActive;

    public string title;
    public string description;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log("Quest Complete");
    }

}
