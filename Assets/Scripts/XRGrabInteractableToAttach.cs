using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableToAttach : XRGrabInteractable
{
    //Ref to Joystick Turn
    public ActionBasedContinuousTurnProvider turnProvider;

    [Header("Grab/release Sounds")]
    private AudioSource audioS;
    public AudioClip grabSound;
    public AudioClip releaseSound;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        turnProvider = GameObject.Find("XR Origin").GetComponent<ActionBasedContinuousTurnProvider>();
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        //play sound when grab obj.
        audioS.clip = grabSound;
        audioS.Play();

        //desactivate rightJoystic turn
        turnProvider.enabled = false;

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        //Play sound when release obj.
        audioS.clip = releaseSound;
        audioS.Play();

        //activate rightJoystic turn
        turnProvider.enabled = true;

        base.OnSelectExited(args);
    }

}
