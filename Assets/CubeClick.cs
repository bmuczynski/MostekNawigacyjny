using UnityEngine;

public class CubeClick : MonoBehaviour
{
    public ScriptGameManager gameManager; // Reference to the GameManager script

    private void OnMouseOver()
    {
        if (gameManager != null)
        {
            gameManager.ObjectClicked(gameObject.tag);
        }
    }
}