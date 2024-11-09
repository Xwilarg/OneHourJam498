using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourJam.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
