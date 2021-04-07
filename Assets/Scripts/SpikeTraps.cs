using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    public List<CharacterControl> charactersTrapped = new List<CharacterControl>();
    public List<DamageDetector> TrappedPlayers = new List<DamageDetector>();
    public List<Spike> trapSpikes = new List<Spike>();

    bool SpikesReady;
    Coroutine SpikeTriggerRoutine;
    void Start()
    {
        SpikeTriggerRoutine = null;
        charactersTrapped.Clear();
        TrappedPlayers.Clear();
        SpikesReady = true;

        Spike[] sp = this.gameObject.GetComponentsInChildren<Spike>();
        foreach (Spike s in sp)
        {
            trapSpikes.Add(s);
        }
    }

    private void Update()
    {
        if (charactersTrapped.Count != 0)
        {
            foreach (CharacterControl control in charactersTrapped)
            {
                if (SpikeTriggerRoutine == null && SpikesReady)
                {
                    SpikeTriggerRoutine = StartCoroutine(_TriggerSpikes());
                }

            }
            if (SpikeTriggerRoutine != null)
            {
                foreach (CharacterControl control in charactersTrapped)
                {
                    if (SpikeTriggerRoutine == null && SpikesReady)
                    {
                        SpikeTriggerRoutine = StartCoroutine(_TriggerSpikes());
                    }

                }
            }
        }

    }
    IEnumerator _TriggerSpikes()
    {
        SpikesReady = false;



        yield return new WaitForSeconds(0.25f);


        foreach (Spike s in trapSpikes)
        {
            s.Activate();
        }

        try
        {
            foreach (DamageDetector d in TrappedPlayers)
            {
                d.TakeDamage(25);
            }
        }
        catch
        {

        }



        yield return new WaitForSeconds(1f);


        foreach (Spike s in trapSpikes)
        {
            s.Deactivate();
        }

        yield return new WaitForSeconds(2f);

        SpikeTriggerRoutine = null;
        SpikesReady = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterControl control = other.gameObject.transform.root.gameObject.GetComponent<CharacterControl>();
        if (control != null)
        {
            if (!charactersTrapped.Contains(control))
            {
                charactersTrapped.Add(control);
                TrappedPlayers.Add(other.gameObject.transform.root.gameObject.GetComponent<DamageDetector>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        CharacterControl control = other.gameObject.transform.root.gameObject.GetComponent<CharacterControl>();
        if (control != null)
        {
            if (charactersTrapped.Contains(control))
            {
                charactersTrapped.Remove(control);
                TrappedPlayers.Remove(other.gameObject.transform.root.gameObject.GetComponent<DamageDetector>());

            }
        }
    }
}
