using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    private Animator JumpscareAnim;

    private void Awake()
    {
        JumpscareAnim = GetComponent<Animator>();
    }

    public void StartJumpScare()
    {
        JumpscareAnim.Play("JumpScare");
    }

    public void EndOfJumpscare()
    {
        SceneManager.LoadScene(2);
    }
}
