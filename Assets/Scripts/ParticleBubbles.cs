using UnityEngine;

public class ParticleBubbles : MonoBehaviour
{
    [SerializeField] private ParticleSystem PS = null;

    private void Awake()
    {
        if (PS == null) PS = GetComponent<ParticleSystem>();
    }
    public void EmitIdea(IIdea GivenIdea)
    {
        GetComponent<ParticleSystemRenderer>().material.SetTexture("_MainTex", GivenIdea.GetIcon().texture);
        PS.Play();
    }

    public ParticleSystem GetParticleSystem() { return PS; }
}