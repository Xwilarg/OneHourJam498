using OneHourJam.Manager;
using TMPro;
using UnityEngine;

namespace OneHourJam.Player
{
    public class Letter : MonoBehaviour
    {
        public char Value { private set; get; }

        public void SetLetter(char c)
        {
            GetComponentInChildren<TMP_Text>().text = c.ToString();
            Value += c;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.AddLetter(Value);
            Destroy(gameObject);
        }
    }
}
