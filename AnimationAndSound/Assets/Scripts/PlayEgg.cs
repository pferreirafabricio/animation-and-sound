using System.Collections;
using UnityEngine;

public class PlayEgg : MonoBehaviour
{
    [SerializeField] private AudioSource EggAudio;
    [SerializeField] private Animator MouthAnimator;

    /// <summary>
    /// Play the sound of the egg and the respective mouth animation
    /// </summary>
    public void Play()
    {
        MouthAnimator.SetBool("StarMouth", true);
        
        if (!EggAudio.isPlaying)
            EggAudio.Play();

        StartCoroutine(StopMouth());
    }

    private IEnumerator StopMouth()
    {
        yield return new WaitForSeconds(3);
        MouthAnimator.SetBool("StarMouth", false);
    }
}
