using System.Collections.Generic;
using System;
public class ListOfProminentIdeologies
{
    private List<IdeologyicalFollowing> FollowedIdeologies = new List<IdeologyicalFollowing>();
    public delegate void NewDomination();
    public static NewDomination OnNewKing;
    public NewDomination LocalOnNewKing;
    public void AddIdeology(IIdea GivenIdea, int Followers)
    {
        FollowedIdeologies.Add(new IdeologyicalFollowing(GivenIdea, Followers));
    }

    public void RemoveNonFollowed()
    {

        FollowedIdeologies.RemoveAll((x) => { return x.GetFollowers() <= 0; });
    }


    public IdeologyicalFollowing FindIdeology(IIdea GivenIdea)
    {
        return FollowedIdeologies.Find((x) => { return x.GetFollowedIdeology().GetDetails().GetName() == GivenIdea.GetDetails().GetName(); });
    }
    public void BubbleSortList()
    {
     
        List<IdeologyicalFollowing> SortedList = FollowedIdeologies;
        if (FollowedIdeologies.Count <= 1) return;
        IIdea TempKing = SortedList[0].GetFollowedIdeology();
        bool itemMoved = false;
        do
        {
            itemMoved = false;
            for (int i = SortedList.Count - 1; i > 0; i--)
            {
                if (SortedList[i].GetFollowers() > SortedList[i - 1].GetFollowers())
                {
                    IdeologyicalFollowing lowerValue = SortedList[i - 1];
                    SortedList[i - 1] = SortedList[i];
                    SortedList[i] = lowerValue;
                    itemMoved = true;
                }
            }
        } while (itemMoved);
        return;
    }
    public List<IdeologyicalFollowing> GetFollowedIdeologies() { return FollowedIdeologies; }

    public void InvokeNewKing() {
        if (LocalOnNewKing != null) LocalOnNewKing.Invoke();
        if (OnNewKing != null) OnNewKing.Invoke(); }
}