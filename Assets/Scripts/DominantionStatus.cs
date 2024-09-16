using UnityEngine;
using System.Collections.Generic;
public static class DominantionStatus
{

    public static int GetDominatedPlaces(IIdea GivenIdea)
    {
        int Dominations = 0;

        foreach(InfluenceSystem IS in GameObject.FindObjectsOfType<InfluenceSystem>())
        {
            List<IdeologyicalFollowing> TempList = IS.GetListOfIdeologies().GetFollowedIdeologies();
            if (TempList.Count <= 0) continue;
            if (TempList[0].GetFollowedIdeology().GetDetails().GetName() == GivenIdea.GetDetails().GetName()) Dominations++;
        }

        return Dominations;
    }

    public static int GetNumberOfInfluenceSystems()
    {
        return GameObject.FindObjectsOfType<InfluenceSystem>().Length;
    }

}