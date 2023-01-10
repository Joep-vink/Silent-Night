using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    public Volume volume;
    public VolumeProfile JpProfile, NormalProfile;
    private Animator JumpscareAnim;

    private void Awake()
    {
        JumpscareAnim = GetComponent<Animator>();
    }

    public void StartJumpScare()
    {
        volume.profile = JpProfile;
        JumpscareAnim.Play("JumpScare");
    }

    public void EndOfJumpscare()
    {
        volume.profile = NormalProfile;
        SceneManager.LoadScene(2);
    }
}
