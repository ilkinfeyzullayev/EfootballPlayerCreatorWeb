using EfootballPlayerCreatorWeb.Enums;

namespace EfootballPlayerCreatorWeb.Models;

public class Stats
{
    public int Height { get; set; }
    public WeakFootAccuracy WeakFootAccuracy { get; set; }
    public int OffensiveAwareness { get; set; }
    public int BallControl { get; set; }
    public int Dribbling { get; set; }
    public int TightPossession { get; set; }
    public int LowPass { get; set; }
    public int LoftedPass { get; set; }
    public int Finishing { get; set; }
    public int Header { get; set; }
    public int PlaceKicking { get; set; }
    public int Curl { get; set; }
    public int Speed { get; set; }
    public int Acceleration { get; set; }
    public int KickingPower { get; set; }
    public int Jump { get; set; }
    public int PhysicalContact { get; set; }
    public int Balance { get; set; }
    public int Stamina { get; set; }
    public int DefensiveAwareness { get; set; }
    public int DefensiveEngagement { get; set; }
    public int Tackling { get; set; }
    public int Aggression { get; set; }
    public int GKAwareness { get; set; }
    public int GKCatching { get; set; }
    public int GKParrying { get; set; }
    public int GKReflexes { get; set; }
    public int GKReach { get; set; }

    public Stats(
        int height,
        WeakFootAccuracy weakFootAccuracy,
        int offensiveAwareness,
        int ballControl,
        int dribbling,
        int tightPossession,
        int lowPass,
        int loftedPass,
        int finishing,
        int header,
        int placeKicking,
        int curl,
        int speed,
        int acceleration,
        int kickingPower,
        int jump,
        int physicalContact,
        int balance,
        int stamina,
        int defensiveAwareness,
        int defensiveEngagement,
        int tackling,
        int aggression,
        int gkAwareness,
        int gkCatching,
        int gkParrying,
        int gkReflexes,
        int gkReach)
    {
        Height = height;
        WeakFootAccuracy = weakFootAccuracy;
        OffensiveAwareness = offensiveAwareness;
        BallControl = ballControl;
        Dribbling = dribbling;
        TightPossession = tightPossession;
        LowPass = lowPass;
        LoftedPass = loftedPass;
        Finishing = finishing;
        Header = header;
        PlaceKicking = placeKicking;
        Curl = curl;
        Speed = speed;
        Acceleration = acceleration;
        KickingPower = kickingPower;
        Jump = jump;
        PhysicalContact = physicalContact;
        Balance = balance;
        Stamina = stamina;
        DefensiveAwareness = defensiveAwareness;
        DefensiveEngagement = defensiveEngagement;
        Tackling = tackling;
        Aggression = aggression;
        GKAwareness = gkAwareness;
        GKCatching = gkCatching;
        GKParrying = gkParrying;
        GKReflexes = gkReflexes;
        GKReach = gkReach;
    }
}