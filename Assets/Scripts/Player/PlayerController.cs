using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _mov;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _mov * 6f;
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>();
        }
    }
}
