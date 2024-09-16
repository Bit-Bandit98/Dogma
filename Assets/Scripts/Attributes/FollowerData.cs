public class FollowerData
{
    private int Followers = 0;

    public FollowerData(int FollowerNumber)
    {
        Followers = FollowerNumber;
    }

    public int GetFollowers() { return Followers; }
    public void SetFollowers(int NewNumber)
    {
        if (NewNumber < 0) Followers = 0;
        else Followers = NewNumber;
    }
    public void AddFollowers(int Adder)
    {
        SetFollowers(Followers + Adder);
    }

}