using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_Fader : ScreenFader
{
    [SerializeField]
    private float _lifeTime = 1f;

    [SerializeField]
    private float _delay = 0.3f;

    protected void Awake()
    {
        _lifeTime = Mathf.Clamp(_lifeTime, FadeOnDuration + FadeOffDuration + _delay, 10f);
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator PlayRoutine()
    {
        SetAlpha(_clearAlpha);
        yield return new WaitForSeconds(_delay);
        FadeOn();
        float onTime = _lifeTime - (FadeOffDuration + _delay);
        yield return new WaitForSeconds(onTime);
        FadeOff();
        Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public static void PlayTransition(Transition_Fader transitionPrefab)
    {
        if(transitionPrefab != null)
        {
            Transition_Fader instance = Instantiate(transitionPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }
}
