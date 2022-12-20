using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public AgentMovement movement;
    Image staminaBar;

    private void Start()
    {
        staminaBar = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        staminaBar.rectTransform.localScale = new Vector3(movement.CurrentStamina, 1); 
    }
}