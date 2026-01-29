using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeFlowCombatSpace
{
    public class MovePlayer : MonoBehaviour
    {
        public float playerSpeed = 5f;

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
                if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                    horizontal -= 1f;
                if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                    horizontal += 1f;
                if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                    vertical -= 1f;
                if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                    vertical += 1f;
            }

            Vector3 move = new Vector3(horizontal, 0, vertical);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero) {
                gameObject.transform.forward = move;
                anim.SetBool("Run", true);
            }else{
                anim.SetBool("Run", false);
            }
        }
    }
}
