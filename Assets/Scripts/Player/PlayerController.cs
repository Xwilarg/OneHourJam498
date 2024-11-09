using OneHourJam.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _mov;

        private Camera _cam;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _cam = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _mov * 6f;

            var bounds = GameManager.CalculateBounds(_cam);
            if (transform.position.x < bounds.min.x * .8f + 1f) transform.position = new(bounds.min.x * .8f + 1f, transform.position.y);
            else if (transform.position.x > bounds.max.x * .8f - 1f) transform.position = new(bounds.max.x * .8f - 1f, transform.position.y);
            if (transform.position.y < bounds.min.y) transform.position = new(transform.position.x, bounds.min.y);
            else if (transform.position.y > bounds.max.y) transform.position = new(transform.position.x, bounds.max.y);
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>();
        }
    }
}
