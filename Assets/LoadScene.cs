using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem
{
    public class LoadScene : MonoBehaviour
    {
        public string sceneToLoad = "mostek";

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Controller"))
            {
                
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
