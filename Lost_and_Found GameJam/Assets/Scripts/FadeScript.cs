using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{

    public bool Fade = false;
    
    public float Duration = .3f;
    public CanvasGroup canvGroup;
    //public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        canvGroup = GetComponent<CanvasGroup>();
        canvGroup.alpha = 0f;
        
    }


    
    public void Fadingin()
    {
        //Switches between .75 and 0 opacity for Fade effect
            StartCoroutine(ScreenFade(canvGroup, canvGroup.alpha, Fade ? .75f : 0));

            Fade = !Fade;

    }

    public IEnumerator ScreenFade(CanvasGroup canvGroup, float start, float end)
    {
        //Creates a timer for how long it takes to go into full fade
        float counter = 0f;

         while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }

    }

}
