using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class Player1Function : MonoBehaviour
{
    [SerializeField] RectTransform player1Transform;
    [SerializeField] RectTransform player2Transform;
    float top = -30;
    float buttom = 30;
    float percentage = 2f;
    AudioSource audioSource;
    public float player1Percentage = 50;
    [SerializeField] Player2Function player2;
    [SerializeField] TextMeshProUGUI tmptext;
    [SerializeField] TextMeshProUGUI pertext;
    [SerializeField] ButtonFunction buttonFunction;
    [SerializeField] AudioClip clip;
    void Start()
    {
        player1Percentage = 50;
        tmptext.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        pertext.text = player1Percentage.ToString();
        if(player1Percentage >= 100)
        {
            WinText();
        }
        if(player2.player2Percentage >= 100)
        {
            LoseText();
        }
    }
    public void Player1ButtonClicked()
    {
        IncreaseBottom(player2Transform, buttom);
        DecreaseTop(player1Transform, top);
        audioSource.PlayOneShot(clip);
        player1Percentage += percentage;
        player2.player2Percentage -= percentage;
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
        pertext.enabled = false;
        StartCoroutine(buttonfunctiondelay());
        tmptext.text = "\n\n"+"Player 1 \n\n"+ "You won\n\n"+ "Keep it up".ToString();
        player1Transform.offsetMin = new Vector2(player1Transform.offsetMin.x, 0);
        player1Transform.offsetMax = new Vector2(player1Transform.offsetMin.x, 0);
    }
    void LoseText()
    {
        tmptext.enabled = true;
        pertext.enabled= false;
        StartCoroutine(buttonfunctiondelay());
        tmptext.text = "\n\n"+"Player 1\n\n"+ "You lose\n\n"+ "Maybe next time".ToString();
        player1Transform.offsetMin = new Vector2(player1Transform.offsetMin.x, 0);
        player1Transform.offsetMax = new Vector2(player1Transform.offsetMin.x, 0);
    }
    IEnumerator buttonfunctiondelay()
    {
        yield return new WaitForSeconds(0.7f);
        buttonFunction.button.image.enabled = true;
        buttonFunction.button.enabled = true;
    }
}
