using System.Collections;
using UnityEngine;
using System;

public class BubbleCollider : MonoBehaviour
{
    public static event Action<bool> LevelWon;

    [SerializeField] private float iFramesSeconds = 0.75f;

    private WaitForSeconds wait4IFrameCoolDown;
    private bool isVulnerable = true;

    private void Awake() { wait4IFrameCoolDown = new WaitForSeconds(iFramesSeconds); }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Obstacle":
                if (!isVulnerable) { break; }
                isVulnerable = false;
                bool hasWon = false;

                Vector3 lowerPosition = transform.position - (Vector3.up * 2);
                if (lowerPosition.y < 0) { hasWon = true; }

                lowerPosition.y = Mathf.Clamp(lowerPosition.y, 0, 4);
                transform.position = lowerPosition;

                collision.gameObject.SetActive(false);
                if (hasWon)
                { LevelWon?.Invoke(false); StartCoroutine("ResetVulnerablity"); }
                else
                { StartCoroutine("ResetVulnerablity"); }

                break;
            case "Collectable":
                if (!isVulnerable) { break; }
                isVulnerable = false;
                bool _hasWon = false;

                Vector3 higherPosition = transform.position + (Vector3.up * 2);
                if (higherPosition.y > 4) { _hasWon = true; }

                higherPosition.y = Mathf.Clamp(higherPosition.y, 0, 4);
                transform.position = higherPosition;

                collision.gameObject.SetActive(false);
                if (_hasWon)
                { LevelWon?.Invoke(true); StartCoroutine("ResetVulnerablity"); }
                else
                { StartCoroutine("ResetVulnerablity"); }

                break;
            default:
                break;
        }
    }

    private IEnumerator ResetVulnerablity()
    {
        //can do some effect stuff prolly
        yield return wait4IFrameCoolDown;
        isVulnerable = true;
    }

}