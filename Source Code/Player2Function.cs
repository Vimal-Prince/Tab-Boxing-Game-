using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2Function : MonoBehaviour
{
    [SerializeField] RectTransform player1Transform;
    [SerializeField] RectTransform player2Transform;
    float top = 30;
    float buttom = -30;
    public float player2Percentage = 50;
    float percentage = 2f;
    AudioSource audioSource;
    [SerializeField] Player1Function player1;
    [SerializeField] TextMeshProUGUI tmptext;
    [SerializeField] TextMeshProUGUI perText;
    [SerializeField] ButtonFunction buttonFunction;
    [SerializeField] AudioClip clip;
    void Start()
    {
        player2Percentage = 50;
        tmptext.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        perText.text = player2Percentage.ToString();
        if(player2Percentage >= 100)
        {
            WinText();
        }
        if(player1.player1Percentage >= 100)
        {
            LoseText();
        }
    }
    public void Player2ButtonClicked()
    {
        IncreaseBottom(player2Transform, buttom);
        DecreaseTop(player1Transform, top);
        audioSource.PlayOneShot(clip);
        player2Percentage += percentage;
        player1.player1Percentage -= percentage;
    }
    void IncreaseBottom(RectTransform rectTransform, float increment)
    {
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, rectTransform.offsetMin.y + increment);
    }
    void DecreaseTop(RectTransform rectTransform, float decrement)
    {
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, rectTransform.offsetMax.y - decrement);
    }
    void WinText()
    {
        tmptext.enabled = true;
        perText.enabled = false;
        StartCoroutine(buttonfunctiondelay());
        tmptext.text = "\n\n"+"Player 2 \n\n"+ "You won\n\n"+ "Keep it up".ToString();
        player2Transform.offsetMin = new Vector2(player2Transform.offsetMin.x, 0);
        player2Transform.offsetMax = new Vector2(player2Transform.offsetMin.x, 0);

    }
    void LoseText()
    {
        tmptext.enabled = true;
        perText.enabled = false;
        StartCoroutine(buttonfunctiondelay());
        tmptext.text = "\n\n"+"Player 2\n\n"+ "You lose\n\n"+ "Maybe next time".ToString();
        player2Transform.offsetMin = new Vector2(player2Transform.offsetMin.x, 0);
        player2Transform.offsetMax = new Vector2(player2Transform.offsetMin.x, 0);
    }
    IEnumerator buttonfunctiondelay()
    {
        yield return new WaitForSeconds(0.7f);
        buttonFunction.button.image.enabled = true;
        buttonFunction.button.enabled = true;
    }
}
