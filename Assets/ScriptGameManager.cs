using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameManager : MonoBehaviour
{
    // Singleton instance
    public static ScriptGameManager instance;

    // UI Text for quest description
    private string questDescriptionText;

    // Quests
    private Queue<Quest> questQueue = new Queue<Quest>();
    private Quest currentQuest;
    private Dictionary<string, GameObject> objectsByTag = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize quests
        InitializeQuests();
        ShowNextQuest();
    }

    // Method to initialize quests
    void InitializeQuests()
    {
        // Create and add quests
        questQueue.Enqueue(new Quest("Witaj! Przed tob¹ znajduje siê symulator mostku nawigacyjnego. Twoim zadaniem bêdzie wykonanie kilku zadan, ktore sprawdzi twoja wiedze na temat najwazniejszych funkcji, ktore sie znajduja na tym mostku, albo jezeli nie miales nigdy z tym stycznosci, naucza co gdzie jest. Kazdy przycisk ktory bedziesz musial nacisnac bedzie znajdowac sie pod niebieskim trojkacikiem. Przed toba pierwsze zadanie do wykonania- znajdz glowny panel sterowania pomp a nastepnie za pomoca swojego kontrolera wcisnij przycisk by go wlaczyc", "Przycisk1","Podpowiedz1"));
        questQueue.Enqueue(new Quest("Po wykonaniu pierwszego zadania, czas aby znalezc panel silnika glownego oraz wcisnac wskazany przycisk. Caly ten panel ma kontrole nad silnikiem, oraz posiada funkcje awaryjnego wylaczania, przekazywania telegrafu na skrzydla itd...", "Przycisk2", "Podpowiedz2"));
        questQueue.Enqueue(new Quest("Przejdzmy teraz do panelu steru strumieniowego. Na poczatku zapoznaj sie z przyciskiem, za pomoca ktorego mozesz rowniez awaryjnie wylaczyc silnik. Na statku istnieje zasada, ktora mowi ze najwazniejsze urzadzenia na mostku musza byc co najmniej po dwie sztuki, w razie awarii pierwszej. Nacisnij ten przycisk.", "Przycisk3", "Podpowiedz3"));
        questQueue.Enqueue(new Quest("Teraz przejdzmy do samego panelu steru strumieniowego. Panel ten pozwala nam na manerwowanie statkiem na boki, najczesciej uzywamy go w momencie kiedy cumujemy do portu. Specjalna wajcha regulujemy moc oraz kierunek w jaka statek ma sie obracac", "Przycisk4", "Podpowiedz4"));
        questQueue.Enqueue(new Quest("Obok panelu steru strumieniowego, ktory rowniez znajduje sie po drugiej stronie mostku, znajduje sie zyrokompas. Wskazuje kurs, wykorzystujac wlasciwoski zyroskopu. Nacisnij go by przejsc do nastepnego zadania", "Przycisk5", "Podpowiedz5"));


        foreach (Quest zadanie in questQueue) {
            StoreObjectsByTag(zadanie.ObjectToShow);
            HideObjectsByTag(zadanie.ObjectToShow);
        }

        // Add more quests as needed
    }

    // Method to show the next quest
    void ShowNextQuest()
    {
        if (questQueue.Count > 0)
        {
            currentQuest = questQueue.Dequeue();
            questDescriptionText = currentQuest.Description;
            ShowObjectsByTag(currentQuest.ObjectToShow);
        }
        else
        {
            // No more quests, clear the description text
            questDescriptionText = "";
        }
    }

    // Method to handle click on objects
    public void ObjectClicked(string objectTag)
    {
        //Debug.Log("Test");
        if (currentQuest != null && objectTag == currentQuest.ObjectToClick)
        {
            currentQuest.Complete();
            HideObjectsByTag(currentQuest.ObjectToShow);
            Debug.Log("Completed Quest: " + currentQuest.Description);
            // Additional quest completion logic goes here

            // Show the next quest
            ShowNextQuest();
        }
    }

    void OnGUI()
    {
            GUI.Label(new Rect(10.0f, 10.0f, 600.0f, 400.0f),"Zadanie \n" + 
                questDescriptionText);
          
    }

    // Function to hide objects by tag
    public void HideObjectsByTag(string tag)
    {
        if (objectsByTag.ContainsKey(tag))
        {
          objectsByTag[tag].SetActive(false); // Hide the object
        }
    }

    // Function to show objects by tag
    public void ShowObjectsByTag(string tag)
    {
        if (objectsByTag.ContainsKey(tag))
        {
            objectsByTag[tag].SetActive(true);
        }
    }

    // Function to store references to objects by tag
    public void StoreObjectsByTag(string tag)
    {
        GameObject obiekt = GameObject.FindGameObjectsWithTag(tag)[0];
        objectsByTag[tag] = obiekt;
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