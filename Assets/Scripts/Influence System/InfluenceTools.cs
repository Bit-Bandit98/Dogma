using UnityEngine;

public class InfluenceTools
{

    public static void Influence(InfluenceSystem Target, IIdea GivenIdea, float Percentage)
    {
        ListOfProminentIdeologies TempList = Target.GetListOfIdeologies();
        if (TempList.GetFollowedIdeologies().Count <= 0)
        {
            TempList.AddIdeology(GivenIdea, Target.GetSituatedIn().GetPopulation());
            return;
        }
        IdeologyicalFollowing TempFollowing = TempList.FindIdeology(GivenIdea);
       
        int PercentOfPopulation = GetPercentageOfPopulation(Target.GetSituatedIn().GetPopulation(), Percentage);
        int TempSiphon = SiphonFollowers(Target, GivenIdea, PercentOfPopulation);
        if (TempFollowing == null) { TempList.AddIdeology(GivenIdea, TempSiphon); }
        else { TempFollowing.AddFollowers(TempSiphon); }

        TempList.RemoveNonFollowed();
        TempList.BubbleSortList();
       
    }

    private static int SiphonFollowers(InfluenceSystem GivenSystem, IIdea Collector, int Target)
    {
        int TempTarget = Target;
        int TempBeforePop;
        foreach(IdeologyicalFollowing FollowedIdea in GivenSystem.GetListOfIdeologies().GetFollowedIdeologies())
        {
            if (FollowedIdea.GetFollowedIdeology().GetDetails().GetName() == Collector.GetDetails().GetName()) continue;
            TempBeforePop = FollowedIdea.GetFollowers();
            FollowedIdea.AddFollowers(-TempTarget);
            TempTarget -= TempBeforePop;

            if (TempTarget <= 0) return Target;
            
        }
        return Target - TempTarget;
    }

    public static int GetPercentageOfPopulation(int Population, float Percentage)
    {
        return Mathf.RoundToInt(Population * Percentage);
    }
}