using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingTask : MonoBehaviour
{

    public string questName;
    [TextArea(2,10)]
    public string Description;
    public GameObject ObjectToClick;
    public bool IsCompleted;
    public GameObject ObjectToShow;

   
    // Method to mark the quest as completed
    public void Complete()
    {
        IsCompleted = true;
    }

    public void InitializeTask()
    {
        //
    }
}

