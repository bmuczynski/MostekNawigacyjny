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
    // UI Text for quest description
    //private string questDescriptionText;

    // Quests
   // private Queue<Quest> questQueue = new Queue<Quest>();
   // private Quest currentQuest;
   // private Dictionary<string, GameObject> objectsByTag = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        TaskNumber = 0; //dajemy wartosc tasknumber na 0
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

    // Method to initialize quests
    void InitializeQuests()
    {
        activeTask = tasks[TaskNumber]; //gamemanager sprawdza ktory task jest aktywny 
        activeTask.InitializeTask();    //aktywny task aktywuje metode initalizetask
        activeTask.IsTaskCompleted += ShowNextQuest; //subkrypcja wydarzen
        

    }

    // Method to show the next quest
    void ShowNextQuest()
    {
        activeTask.IsTaskCompleted -= ShowNextQuest; //unsubksrypcja wydarzen
        TaskNumber++; //dodajemy numer taska jeden w gore, jako ze jest to nowy task

        if (TaskNumber < tasks.Count)
        {
            OnboardingTask onboardingTask = tasks[TaskNumber];
            activeTask = onboardingTask;
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