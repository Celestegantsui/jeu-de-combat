using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeflowCombatSpace
{
    public class SetInputs : MonoBehaviour
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
            // left mouse click to attack
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
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


            // SETTING THE INPUTS
            float horizontal = 0f;
            float vertical = 0f;

            if (Gamepad.current != null)
            {
                Vector2 stick = Gamepad.current.leftStick.ReadValue();
                horizontal = stick.x;
                vertical = stick.y;
            }
            else if (Keyboard.current != null)
            {
                if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                    horizontal -= 1f;
                if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                    horizontal += 1f;
                if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                    vertical -= 1f;
                if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                    vertical += 1f;
            }

            freeFlowCombat.xInput = horizontal;
            freeFlowCombat.yInput = vertical;
        }
    }
}

