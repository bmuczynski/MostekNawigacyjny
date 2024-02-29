using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainPompPanel;
    public GameObject bowThruster;

    private bool mainPompPanelInteracted;
    private bool bowThrusterInteracted;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == mainPompPanel && !mainPompPanelInteracted)
                {
                    InteractWithMainPompPanel();
                }
                else if (hit.collider.gameObject == bowThruster && mainPompPanelInteracted && !bowThrusterInteracted)
                {
                    InteractWithBowThruster();
                }
            }
        }
    }

    void InteractWithMainPompPanel()
    {
        Debug.Log("Interacted with main pomp panel");
        mainPompPanelInteracted = true;
    }

    void InteractWithBowThruster()
    {
        Debug.Log("Interacted with bow thruster");
        bowThrusterInteracted = true;
    }
}
