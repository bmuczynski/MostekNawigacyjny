using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ExitGame : UIElement
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
