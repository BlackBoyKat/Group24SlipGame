using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour
{
    public SpriteRenderer beatBorder;
    public Color OriginalColor;
    public Color FadedColor;

    private Vector3 startScale;
    private Vector3 endScale;



    void Start()
    {

        StartCoroutine(AlphaLerp());
        startScale = new Vector3(2f, 2f, 1f);
        endScale = beatBorder.transform.localScale;
        beatBorder.transform.localScale = startScale;
    }

    public IEnumerator AlphaLerp()
    {
        float duration = 1.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (beatBorder == null) break;

            elapsed += Time.deltaTime;
            float percentage = elapsed / duration;

            // Smoothly lerp scale and color
            beatBorder.transform.localScale = Vector3.Lerp(startScale, endScale, percentage);
            beatBorder.color = Color.Lerp(OriginalColor, FadedColor, percentage);

            yield return null;
        }
    }


    public void OnMouseDown()
    {
        int currentScore = 0;
        int scorePerNote = 100;
        currentScore += scorePerNote;//adds on to score 
        scorePerNote++;
        Debug.Log("Hit! Score: " + currentScore);
        Destroy(gameObject);
    }
}
