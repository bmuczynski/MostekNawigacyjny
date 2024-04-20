//======= Copyright (c) Valve Corporation, All rights reserved. ===============

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

            // SprawdŸ, czy nazwa sceny zosta³a ustawiona
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                // Za³aduj now¹ scenê
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("blad");
            }
        }
    }
}
