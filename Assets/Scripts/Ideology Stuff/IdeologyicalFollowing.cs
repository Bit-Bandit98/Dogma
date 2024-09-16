using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeologyicalFollowing 
{
    private IdeologyOffspring FollowedIdeology = null;
    private FollowerData Followerdata = null;

    public IdeologyicalFollowing(IIdea GivenIdea, int StartingFollowers)
    {
        FollowedIdeology = new IdeologyOffspring(GivenIdea);
        Followerdata = new FollowerData(StartingFollowers);
    }

    public IdeologyOffspring GetFollowedIdeology() { return FollowedIdeology; }
    public int GetFollowers() { return Followerdata.GetFollowers(); }
    public void AddFollowers(int Value) { Followerdata.AddFollowers(Value); }
}
