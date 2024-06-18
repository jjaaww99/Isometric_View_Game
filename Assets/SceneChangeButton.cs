using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    public int sceneIndex;
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick(sceneIndex));
    }

    private void OnButtonClick(int sceneindex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
