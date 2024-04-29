using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class SceneChangerUI : UIElement
    {
        public string sceneToLoad = "mostek";
            
        protected override void OnButtonClick()
        {
            base.OnButtonClick();

           
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
               
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("blad");
            }
        }
    }
}
