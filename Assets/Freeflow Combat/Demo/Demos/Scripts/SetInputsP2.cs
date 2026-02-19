using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeflowCombatSpace
{
    public class SetInputsP2 : MonoBehaviour
    {
        FreeflowCombat freeFlowCombat;
        public AudioSource whooshSound;
        public TrailRenderer tr;

        void Start()
        {
            freeFlowCombat = GetComponent<FreeflowCombat>();
        }

        void Update()
        {
            // right mouse click to attack for player 2
            if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame) {
                freeFlowCombat.Attack();
            }

            // play woosh sound
            if (freeFlowCombat.isTraversing) {
                if (!whooshSound.isPlaying) whooshSound.Play();
            }
            else {
                whooshSound.Stop();
            }

            // enable the trail if either traversing or attacking
            if (freeFlowCombat.isTraversing || freeFlowCombat.isAttacking) tr.enabled = true;
            else tr.enabled = false;

            // SETTING THE INPUTS FOR PLAYER 2 (ARROW KEYS)
            float horizontal = 0f;
            float vertical = 0f;

            if (Keyboard.current != null)
            {
                if (Keyboard.current.leftArrowKey.isPressed)
                    horizontal -= 1f;
                if (Keyboard.current.rightArrowKey.isPressed)
                    horizontal += 1f;
                if (Keyboard.current.downArrowKey.isPressed)
                    vertical -= 1f;
                if (Keyboard.current.upArrowKey.isPressed)
                    vertical += 1f;
            }

            freeFlowCombat.xInput = horizontal;
            freeFlowCombat.yInput = vertical;
        }
    }
}

