using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    public Button[] buttons;
    public Canvas canvas;
    public Image startScreenPanel;
    public Image InGamePanel;
    public Image fadeImage;

    const int startSceneIndex = 0;
    const int recordSceneIndex = 1;
    const int gameSceneIndex = 2;


    public static SceneController Instance
    { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        buttons = GetComponentsInChildren<Button>();

        canvas = GetComponentInChildren<Canvas>();
        
        fadeImage.gameObject.SetActive(false);

        InGamePanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (buttons != null && buttons.Length > 0)
        {
            buttons[0].onClick.AddListener(ToPlayScene);
            buttons[1].onClick.AddListener(ToRecordRoomScene);
            buttons[2].onClick.AddListener(QuitGame);
            buttons[3].onClick.AddListener(ToStartScene);
            buttons[4].onClick.AddListener(ToRecordRoomScene);
            buttons[5].onClick.AddListener(QuitGame);
        }
    }

    private void Update()
    {
        if (GameManager.instance != null && GameManager.instance.gameState == GameState.Playing)
        {
            startScreenPanel.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvas.gameObject.activeSelf)
                {
                    canvas.gameObject.SetActive(false);
                    InGamePanel.gameObject.SetActive(false);
                }
                else
                {
                    canvas.gameObject.SetActive(true);
                    InGamePanel.gameObject.SetActive(true);
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToPlayScene()
    {
        StartCoroutine(FadeAndChangeScene(gameSceneIndex));
    }
    public void ToRecordRoomScene()
    {
        StartCoroutine(FadeAndChangeScene(recordSceneIndex));
    }
    public void ToStartScene()
    {
        StartCoroutine(FadeAndChangeScene(startSceneIndex));
    }

    public float fadeSpeed;
    public float fadeDurataion;

    private IEnumerator FadeAndChangeScene(int sceneIndex)
    {
        float elapsedTime = 0;

        canvas.gameObject.SetActive(true);
        fadeImage.gameObject.SetActive(true);

        while (elapsedTime <= fadeDurataion)
        {
            elapsedTime += Time.deltaTime;

            Color fade = new Color(0, 0, 0, elapsedTime * fadeSpeed);

            fadeImage.color = fade;

            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);

        startScreenPanel.gameObject.SetActive(false);

        while (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;

            Color fade = new Color(0, 0, 0, elapsedTime * fadeSpeed);

            fadeImage.color = fade;

            yield return null;
        }

        if (sceneIndex == startSceneIndex)
        {
            InGamePanel.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
            startScreenPanel.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
            startScreenPanel.gameObject.SetActive(false);
        }

        fadeImage.gameObject.SetActive(false);
    }

}
