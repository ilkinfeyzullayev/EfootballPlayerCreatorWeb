using EfootballPlayerCreatorWeb.Enums;

namespace EfootballPlayerCreatorWeb.Models;

public class Player
{
    public string Name { get; set; }
    public int Overall { get; private set; }
    public double ExactOverall { get; private set; }
    public Position Position { get; set; }
    public Stats Stats { get; set; }

    public Player(string name, Position position, Stats stats)
    {
        Name = name;
        Position = position;
        Stats = stats;
    }

    public void CalculateOverall()
    {
        AdjustedStats adjusted = new(Stats);

        double total = 0;

        foreach (var (stat, weight) in overallCalculationData[Position])
        {
            total += adjusted.GetStat(stat) * weight;
        }

        total += adjusted.WeakFootAccuracy;

        ExactOverall = Math.Round((total + 500) / 1000.0, 2);

        Overall = (int)Math.Floor(ExactOverall);
    }

    private static readonly Dictionary<Position, Dictionary<Stat, double>> overallCalculationData = new()
    {
        [Position.GK] = new()
        {
            [Stat.Height] = 186,
            [Stat.OffensiveAwareness] = 0,
            [Stat.BallControl] = 13,
            [Stat.Dribbling] = 0,
            [Stat.TightPossession] = 0,
            [Stat.LowPass] = 27,
            [Stat.LoftedPass] = 40,
            [Stat.Finishing] = 0,
            [Stat.Header] = 0,
            [Stat.PlaceKicking] = 0,
            [Stat.Curl] = 0,
            [Stat.Speed] = 13,
            [Stat.Acceleration] = 40,
            [Stat.KickingPower] = 53,
            [Stat.Jump] = 133,
            [Stat.PhysicalContact] = 80,
            [Stat.Balance] = 0,
            [Stat.Stamina] = 0,
            [Stat.DefensiveAwareness] = 13,
            [Stat.DefensiveEngagement] = 0,
            [Stat.Tackling] = 0,
            [Stat.Aggression] = 0,
            [Stat.GKAwareness] = 279,
            [Stat.GKCatching] = 226,
            [Stat.GKParrying] = 173,
            [Stat.GKReflexes] = 173,
            [Stat.GKReach] = 226
        },

        [Position.CB] = new()
        {
            [Stat.Height] = 136,
            [Stat.OffensiveAwareness] = 14,
            [Stat.BallControl] = 27,
            [Stat.Dribbling] = 14,
            [Stat.TightPossession] = 0,
            [Stat.LowPass] = 41,
            [Stat.LoftedPass] = 68,
            [Stat.Finishing] = 27,
            [Stat.Header] = 55,
            [Stat.PlaceKicking] = 14,
            [Stat.Curl] = 14,
            [Stat.Speed] = 136,
            [Stat.Acceleration] = 150,
            [Stat.KickingPower] = 27,
            [Stat.Jump] = 109,
            [Stat.PhysicalContact] = 204,
            [Stat.Balance] = 0,
            [Stat.Stamina] = 68,
            [Stat.DefensiveAwareness] = 286,
            [Stat.DefensiveEngagement] = 14,
            [Stat.Tackling] = 191,
            [Stat.Aggression] = 82,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.RB] = new()
        {
            [Stat.Height] = 49,
            [Stat.OffensiveAwareness] = 61,
            [Stat.BallControl] = 86,
            [Stat.Dribbling] = 61,
            [Stat.TightPossession] = 37,
            [Stat.LowPass] = 61,
            [Stat.LoftedPass] = 147,
            [Stat.Finishing] = 24,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 24,
            [Stat.Curl] = 24,
            [Stat.Speed] = 220,
            [Stat.Acceleration] = 184,
            [Stat.KickingPower] = 24,
            [Stat.Jump] = 37,
            [Stat.PhysicalContact] = 98,
            [Stat.Balance] = 24,
            [Stat.Stamina] = 196,
            [Stat.DefensiveAwareness] = 147,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 86,
            [Stat.Aggression] = 37,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.LB] = new()
        {
            [Stat.Height] = 49,
            [Stat.OffensiveAwareness] = 61,
            [Stat.BallControl] = 86,
            [Stat.Dribbling] = 61,
            [Stat.TightPossession] = 37,
            [Stat.LowPass] = 61,
            [Stat.LoftedPass] = 147,
            [Stat.Finishing] = 24,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 24,
            [Stat.Curl] = 24,
            [Stat.Speed] = 220,
            [Stat.Acceleration] = 184,
            [Stat.KickingPower] = 24,
            [Stat.Jump] = 37,
            [Stat.PhysicalContact] = 98,
            [Stat.Balance] = 24,
            [Stat.Stamina] = 196,
            [Stat.DefensiveAwareness] = 147,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 86,
            [Stat.Aggression] = 37,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.DMF] = new()
        {
            [Stat.Height] = 61,
            [Stat.OffensiveAwareness] = 61,
            [Stat.BallControl] = 122,
            [Stat.Dribbling] = 37,
            [Stat.TightPossession] = 24,
            [Stat.LowPass] = 122,
            [Stat.LoftedPass] = 122,
            [Stat.Finishing] = 37,
            [Stat.Header] = 61,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 61,
            [Stat.Acceleration] = 61,
            [Stat.KickingPower] = 49,
            [Stat.Jump] = 37,
            [Stat.PhysicalContact] = 122,
            [Stat.Balance] = 12,
            [Stat.Stamina] = 196,
            [Stat.DefensiveAwareness] = 220,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 122,
            [Stat.Aggression] = 98,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.CMF] = new()
        {
            [Stat.Height] = 37,
            [Stat.OffensiveAwareness] = 98,
            [Stat.BallControl] = 171,
            [Stat.Dribbling] = 98,
            [Stat.TightPossession] = 49,
            [Stat.LowPass] = 208,
            [Stat.LoftedPass] = 159,
            [Stat.Finishing] = 73,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 61,
            [Stat.Acceleration] = 86,
            [Stat.KickingPower] = 73,
            [Stat.Jump] = 12,
            [Stat.PhysicalContact] = 49,
            [Stat.Balance] = 24,
            [Stat.Stamina] = 196,
            [Stat.DefensiveAwareness] = 86,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 86,
            [Stat.Aggression] = 37,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.RMF] = new()
        {
            [Stat.Height] = 12,
            [Stat.OffensiveAwareness] = 98,
            [Stat.BallControl] = 171,
            [Stat.Dribbling] = 110,
            [Stat.TightPossession] = 73,
            [Stat.LowPass] = 135,
            [Stat.LoftedPass] = 196,
            [Stat.Finishing] = 86,
            [Stat.Header] = 12,
            [Stat.PlaceKicking] = 24,
            [Stat.Curl] = 24,
            [Stat.Speed] = 196,
            [Stat.Acceleration] = 159,
            [Stat.KickingPower] = 24,
            [Stat.Jump] = 12,
            [Stat.PhysicalContact] = 24,
            [Stat.Balance] = 61,
            [Stat.Stamina] = 147,
            [Stat.DefensiveAwareness] = 49,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 24,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.LMF] = new()
        {
            [Stat.Height] = 12,
            [Stat.OffensiveAwareness] = 98,
            [Stat.BallControl] = 171,
            [Stat.Dribbling] = 122,
            [Stat.TightPossession] = 61,
            [Stat.LowPass] = 135,
            [Stat.LoftedPass] = 196,
            [Stat.Finishing] = 86,
            [Stat.Header] = 12,
            [Stat.PlaceKicking] = 24,
            [Stat.Curl] = 24,
            [Stat.Speed] = 196,
            [Stat.Acceleration] = 159,
            [Stat.KickingPower] = 24,
            [Stat.Jump] = 12,
            [Stat.PhysicalContact] = 24,
            [Stat.Balance] = 61,
            [Stat.Stamina] = 147,
            [Stat.DefensiveAwareness] = 49,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 24,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.AMF] = new()
        {
            [Stat.Height] = 37,
            [Stat.OffensiveAwareness] = 171,
            [Stat.BallControl] = 196,
            [Stat.Dribbling] = 122,
            [Stat.TightPossession] = 73,
            [Stat.LowPass] = 196,
            [Stat.LoftedPass] = 159,
            [Stat.Finishing] = 184,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 98,
            [Stat.Acceleration] = 86,
            [Stat.KickingPower] = 73,
            [Stat.Jump] = 12,
            [Stat.PhysicalContact] = 24,
            [Stat.Balance] = 24,
            [Stat.Stamina] = 86,
            [Stat.DefensiveAwareness] = 24,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 24,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.RWF] = new()
        {
            [Stat.Height] = 49,
            [Stat.OffensiveAwareness] = 159,
            [Stat.BallControl] = 159,
            [Stat.Dribbling] = 159,
            [Stat.TightPossession] = 86,
            [Stat.LowPass] = 73,
            [Stat.LoftedPass] = 98,
            [Stat.Finishing] = 159,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 220,
            [Stat.Acceleration] = 159,
            [Stat.KickingPower] = 61,
            [Stat.Jump] = 24,
            [Stat.PhysicalContact] = 37,
            [Stat.Balance] = 73,
            [Stat.Stamina] = 49,
            [Stat.DefensiveAwareness] = 12,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 12,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.LWF] = new()
        {
            [Stat.Height] = 49,
            [Stat.OffensiveAwareness] = 159,
            [Stat.BallControl] = 159,
            [Stat.Dribbling] = 159,
            [Stat.TightPossession] = 86,
            [Stat.LowPass] = 73,
            [Stat.LoftedPass] = 98,
            [Stat.Finishing] = 159,
            [Stat.Header] = 24,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 220,
            [Stat.Acceleration] = 159,
            [Stat.KickingPower] = 61,
            [Stat.Jump] = 24,
            [Stat.PhysicalContact] = 37,
            [Stat.Balance] = 73,
            [Stat.Stamina] = 49,
            [Stat.DefensiveAwareness] = 12,
            [Stat.DefensiveEngagement] = 24,
            [Stat.Tackling] = 12,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.SS] = new()
        {
            [Stat.Height] = 62,
            [Stat.OffensiveAwareness] = 173,
            [Stat.BallControl] = 210,
            [Stat.Dribbling] = 123,
            [Stat.TightPossession] = 86,
            [Stat.LowPass] = 99,
            [Stat.LoftedPass] = 74,
            [Stat.Finishing] = 284,
            [Stat.Header] = 25,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 86,
            [Stat.Acceleration] = 99,
            [Stat.KickingPower] = 99,
            [Stat.Jump] = 37,
            [Stat.PhysicalContact] = 37,
            [Stat.Balance] = 74,
            [Stat.Stamina] = 49,
            [Stat.DefensiveAwareness] = 0,
            [Stat.DefensiveEngagement] = 12,
            [Stat.Tackling] = 12,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        },

        [Position.CF] = new()
        {
            [Stat.Height] = 99,
            [Stat.OffensiveAwareness] = 210,
            [Stat.BallControl] = 123,
            [Stat.Dribbling] = 62,
            [Stat.TightPossession] = 37,
            [Stat.LowPass] = 37,
            [Stat.LoftedPass] = 12,
            [Stat.Finishing] = 358,
            [Stat.Header] = 62,
            [Stat.PlaceKicking] = 12,
            [Stat.Curl] = 12,
            [Stat.Speed] = 99,
            [Stat.Acceleration] = 123,
            [Stat.KickingPower] = 123,
            [Stat.Jump] = 62,
            [Stat.PhysicalContact] = 86,
            [Stat.Balance] = 86,
            [Stat.Stamina] = 37,
            [Stat.DefensiveAwareness] = 0,
            [Stat.DefensiveEngagement] = 12,
            [Stat.Tackling] = 12,
            [Stat.Aggression] = 12,
            [Stat.GKAwareness] = 0,
            [Stat.GKCatching] = 0,
            [Stat.GKParrying] = 0,
            [Stat.GKReflexes] = 0,
            [Stat.GKReach] = 0
        }
    };
}