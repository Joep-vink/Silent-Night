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
        staminaBar.rectTransform.sizeDelta = new Vector3(Mathf.Clamp(movement.stamina * 50,0,500), 50); 
    }
}
