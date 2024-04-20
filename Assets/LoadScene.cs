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

            // Sprawd�, czy nazwa sceny zosta�a ustawiona
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                // Za�aduj now� scen�
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("blad");
            }
        }
    }
}
