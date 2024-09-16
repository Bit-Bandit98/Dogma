using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TargetSkill : Skill
{
    
    private GameObject GivenTargetForSkill = null;
    [SerializeField] private UnityEvent OnTargetAcquired = null;
    [SerializeField] private Targeter.TargetType TargetMode;
    public void SetTarget()
    {
        GivenTargetForSkill = Targeter.GetTarget();
    }
    public GameObject GetTarget()
    {
        return GivenTargetForSkill;
    }

    public void ActivateOnTargetAquired()
    {
        if (OnTargetAcquired != null) OnTargetAcquired.Invoke();
    }

    public Targeter.TargetType GetTargetMode()
    {
        return TargetMode;
    }
}