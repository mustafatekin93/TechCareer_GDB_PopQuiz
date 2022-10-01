using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButons : MonoBehaviour
{
    public Animator pipeAnimator;
    public Animator startButonAnimator;
    public Animator howToButonAnimator;
    public Animator quitButonAnimator;
    public Animator howToAnimator;
    public GameObject startButon;
    public GameObject howToButon;
    public GameObject quitButon;

    public void StartGame()
    {
        pipeAnimator.SetTrigger("showPipe");
        hideButtons();
    }

    public void HowToPlay()
    {
        howToAnimator.SetTrigger("showHowTo");
        pipeAnimator.SetTrigger("showPipe");
        hideButtons();
    }

    void hideButtons()
    {
        startButonAnimator.SetTrigger("fade");
        howToButonAnimator.SetTrigger("fade");
        quitButonAnimator.SetTrigger("fade");
        StartCoroutine(_hideButtons());

        IEnumerator _hideButtons()
        {
            yield return new WaitForSeconds(1);
            startButon.SetActive(false);
            howToButon.SetActive(false);
            quitButon.SetActive(false);
        }
    }


}
