using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnboardingTask : MonoBehaviour
{

    public string questName;
    [TextArea(2,10)]
    public string Description;
    public GameObject ObjectToClick;
    public bool isActive;
    public GameObject ObjectToShow;
    public GameObject HintToShow;
    public Text QuestText;
    public event Action IsTaskCompleted;

    private void Start()
    {
        isActive = false;
       
    }

    // Method to mark the quest as completed
    public void Complete()
    {
        print("Task zakonczony");
        isActive = false;
        QuestText.gameObject.SetActive(false);
        ObjectToShow.gameObject.SetActive(false);
        HintToShow.gameObject.SetActive(false);
        IsTaskCompleted.Invoke();
        ObjectToClick.gameObject.SetActive(false);
       
        GetComponent<AudioSource>().Play(); 
    }

    public void InitializeTask()
    {
        QuestText.text = Description;
            ObjectToShow.SetActive(true);
        HintToShow.gameObject.SetActive(true);
        
            isActive = true;
    }

    private void Update()
    {

        if(isActive && Input.GetKeyUp(KeyCode.Space)) 
        {
            print("obsluga przycisku z taska " + gameObject.name);
            Invoke("Complete" , 1.0f);
        }
    }
}

