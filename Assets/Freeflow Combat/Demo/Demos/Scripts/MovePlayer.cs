using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeFlowCombatSpace
{
    public class MovePlayer : MonoBehaviour
    {
        public float playerSpeed = 5f;

        public int playerID = 1;

        CharacterController controller;
        Animator anim;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float horizontal = 0f;
            float vertical = 0f;

            if (Keyboard.current != null)
            {
                // PLAYER 1 = ZQSD (AZERTY)
                if (playerID == 1)
                {
                    if (Keyboard.current.qKey.isPressed)
                        horizontal -= 1f;

                    if (Keyboard.current.dKey.isPressed)
                        horizontal += 1f;

                    if (Keyboard.current.sKey.isPressed)
                        vertical -= 1f;

                    if (Keyboard.current.zKey.isPressed)
                        vertical += 1f;
                }

                // PLAYER 2 = FLECHES
                else if (playerID == 2)
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
            }

            Vector3 move = new Vector3(horizontal, 0, vertical);

            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                transform.forward = move;
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    }
}
