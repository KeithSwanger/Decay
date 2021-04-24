using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonReturnToMainMenu : MonoBehaviour
{
    public Button button;
    public string sceneToLoad;
    public CanvasGroup canvasGroup;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (canvasGroup.alpha > 0f)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
