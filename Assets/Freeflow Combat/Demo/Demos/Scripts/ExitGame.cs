using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeflowCombatSpace
{
    public class ExitGame : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) {
                QuitGame();
            }
        }

        void QuitGame() 
        {
            #if UNITY_STANDALONE
                Application.Quit();
            #endif

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}

