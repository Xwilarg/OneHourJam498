using OneHourJam.Player;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OneHourJam.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameObject _letter;

        [SerializeField]
        private TMP_Text _word;

        [SerializeField]
        private TMP_Text _hint;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private Sprite[] _sprites;

        private string _wValue = string.Empty;

        private Camera _cam;

        private int _index;

        private string[] _words = new[]
        {
            "ROBE",
            "CULOTTE"
        };

        private void Awake()
        {
            Instance = this;
            _cam = Camera.main;

            _hint.text = _words[_index];
            var letters = _words.SelectMany(x => x.ToCharArray()).Distinct();
            foreach (var l in letters)
            {
                SpawnLetter(l);
            }
        }

        public void AddLetter(char c)
        {
            _wValue += c;

            if (_words[_index].ToUpperInvariant() == _wValue.ToUpperInvariant())
            {
                _index++;
                _hint.text = _words[_index];
                _image.sprite = _sprites[_index];
                _wValue = string.Empty;
            }
            if (_words[_index].StartsWith(_wValue, System.StringComparison.InvariantCultureIgnoreCase))
            {
                // OK
            }
            else
            {
                _wValue = string.Empty;
            }
            _word.text = _wValue;

            SpawnLetter(c);
        }

        private void SpawnLetter(char c)
        {
            var bounds = CalculateBounds(_cam);

            Vector2 pos;
            do
            {
                pos = new Vector2(Random.Range(bounds.min.x + 3f, bounds.max.x - 3f), Random.Range(bounds.min.y + 1f, bounds.max.y - 1f));
            }
            while (Physics2D.OverlapCircle(pos, 1f, LayerMask.GetMask("Player", "Letter")));

            var go = Instantiate(_letter, pos, Quaternion.identity);
            go.GetComponent<Letter>().SetLetter(c);
        }

        // http://answers.unity.com/answers/502236/view.html
        public static Bounds CalculateBounds(Camera cam)
        {
            float screenAspect = Screen.width / (float)Screen.height;
            float cameraHeight = cam.orthographicSize * 2;
            Bounds bounds = new(
                cam.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
}
