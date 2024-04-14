using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ExitGame : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Controller"))
            {
                
                Application.Quit();
            }
        }
    }
}
