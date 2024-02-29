using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Object Clicked: " + gameObject.name);
        // Additional logic for when the object is clicked
    }
}
