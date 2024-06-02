using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public Button button;
    void Awake()
    {
        button.enabled = false;
        button.image.enabled = false;
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
