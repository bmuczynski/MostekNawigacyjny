using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectReference", menuName = "Custom/Object Reference")]
public class test : ScriptableObject
{
    public string referencedPrefab = "Player";

    public GameObject obj;

    public void SetReference(string prefab)
    {
        
    }


    private void Awake()
    {
        obj = GameObject.Find(referencedPrefab);
    }

}
