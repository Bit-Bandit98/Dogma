using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceParticles : MonoBehaviour
{
    [SerializeField] private GameObject ParticleSystem = null;
    private ParticleBubbles[] CreatedParticles;


    private void Start()
    {
        CreateParticleSystems(4);
    }
    private void CreateParticleSystems(int Number)
    {
        CreatedParticles = new ParticleBubbles[Number];
       for(int i = 0; i < Number; i++)
        {
            GameObject NewParticles = Instantiate(ParticleSystem);
            NewParticles.transform.SetParent(this.transform);
            NewParticles.transform.localPosition = Vector3.up;
            CreatedParticles[i] = NewParticles.GetComponent<ParticleBubbles>();
        }
    }

    public void PlayParticles(IIdea GivenIdea)
    {
        if (GivenIdea.GetDetails().GetName() == PredefinedIdeologies.Singleton.GetApathetic().GetDetails().GetName()) return;
        for(int i = 0; i < CreatedParticles.Length; i++)
        {
            if (CreatedParticles[i].GetParticleSystem().isPlaying) continue;
            else
            {
                CreatedParticles[i].EmitIdea(GivenIdea);
                break;
            }
        }
    }
}