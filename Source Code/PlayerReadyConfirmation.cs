using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerReadyConfirmation : MonoBehaviour
{
    [SerializeField] Image player1Confirmation;
    [SerializeField] Image player2Confirmation;

    void Awake() 
    {
        player1Confirmation.enabled = false;
        player2Confirmation.enabled = false;
    }
    public void Player1Conformation()
    {
        player1Confirmation.enabled = true;
    }
    public void Player2Conformation()
    {
        player2Confirmation.enabled = true;
    }
    void Update() 
    {
        if (player1Confirmation.enabled && player2Confirmation.enabled)
        {
            SceneManager.LoadScene(2);
        }
    }
}
