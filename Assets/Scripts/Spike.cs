using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void Activate()
    {
        if (this.transform.localPosition.y < 0f)
        {
            StartCoroutine(_Activate());
        }
    }

    IEnumerator _Activate()
    {
        yield return new WaitForSeconds(0.1f);
        this.transform.localPosition += (Vector3.up * 1f);
    }

    public void Deactivate()
    {
        if (this.transform.localPosition.y > 0f)
        {
            StartCoroutine(_Deactivate());
        }
    }

    IEnumerator _Deactivate()
    {
        yield return new WaitForSeconds(0.1f);
        this.transform.localPosition -= (Vector3.up * 1f);
    }
}
