using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameManager : MonoBehaviour
{
    public static ScriptGameManager instance;

    public List<OnboardingTask> tasks;
    public OnboardingTask activeTask;
    public int TaskNumber;
    void Start()
    {
        TaskNumber = 0;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
        InitializeQuests();
        
    }

    
    void InitializeQuests()
    {
        activeTask = tasks[TaskNumber]; 
        activeTask.InitializeTask();   
        activeTask.IsTaskCompleted += ShowNextQuest; 
        

    }

    void ShowNextQuest()
    {
        activeTask.IsTaskCompleted -= ShowNextQuest; 
        TaskNumber++;

        if (TaskNumber < tasks.Count)
        {
            OnboardingTask onboardingTask = tasks[TaskNumber];
            activeTask = onboardingTask
            activeTask.InitializeTask();
            activeTask.IsTaskCompleted += ShowNextQuest;
    }

        else
        {
            print("Nie ma wiecej taskow");
    Application.Quit();
        }


    }

 

   
    
  

  

  
}

// Quest class
public class Quest
{
    public string Description { get; private set; }
    public string ObjectToClick { get; private set; }
    public bool IsCompleted { get; private set; }
    public string ObjectToShow { get; private set; }

    public Quest(string description, string objectToClick, string objectToShow)
    {
        Description = description;
        ObjectToClick = objectToClick;
        IsCompleted = false;
        ObjectToShow = objectToShow;
    }

    // Method to mark the quest as completed
    public void Complete()
    {
        IsCompleted = true;
    }


}