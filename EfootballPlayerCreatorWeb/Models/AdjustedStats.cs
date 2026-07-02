using EfootballPlayerCreatorWeb.Enums;

namespace EfootballPlayerCreatorWeb.Models;

public class AdjustedStats
{
    private readonly Stats _stats;

    public AdjustedStats(Stats stats)
    {
        _stats = stats;
    }

    public int Height => _stats.Height - 136;
    public int WeakFootAccuracy
    {
        get
        {
            int value = _stats.WeakFootAccuracy switch
            {
                EfootballPlayerCreatorWeb.Enums.WeakFootAccuracy.Low => 0,
                EfootballPlayerCreatorWeb.Enums.WeakFootAccuracy.Medium => 1,
                EfootballPlayerCreatorWeb.Enums.WeakFootAccuracy.High => 2,
                EfootballPlayerCreatorWeb.Enums.WeakFootAccuracy.VeryHigh => 3,
                _ => 0
            };

            return 4 * (int)Math.Floor(value * 59.0 / 3 + 40) - 100;
        }
    }
    public int OffensiveAwareness => _stats.OffensiveAwareness - 25;
    public int BallControl => _stats.BallControl - 25;
    public int Dribbling => _stats.Dribbling - 25;
    public int TightPossession => _stats.TightPossession - 25;
    public int LowPass => _stats.LowPass - 25;
    public int LoftedPass => _stats.LoftedPass - 25;
    public int Finishing => _stats.Finishing - 25;
    public int Header => _stats.Header - 25;
    public int PlaceKicking => _stats.PlaceKicking - 25;
    public int Curl => _stats.Curl - 25;
    public int Speed => _stats.Speed - 25;
    public int Acceleration => _stats.Acceleration - 25;
    public int KickingPower => _stats.KickingPower - 25;
    public int Jump => _stats.Jump - 25;
    public int PhysicalContact => _stats.PhysicalContact - 25;
    public int Balance => _stats.Balance - 25;
    public int Stamina => _stats.Stamina - 25;
    public int DefensiveAwareness => _stats.DefensiveAwareness - 25;
    public int DefensiveEngagement => _stats.DefensiveEngagement - 25;
    public int Tackling => _stats.Tackling - 25;
    public int Aggression => _stats.Aggression - 25;
    public int GKAwareness => _stats.GKAwareness - 25;
    public int GKCatching => _stats.GKCatching - 25;
    public int GKParrying => _stats.GKParrying - 25;
    public int GKReflexes => _stats.GKReflexes - 25;
    public int GKReach => _stats.GKReach - 25;

    public int GetStat(Stat stat)
    {
        return stat switch
        {
            Stat.Height => Height,
            Stat.OffensiveAwareness => OffensiveAwareness,
            Stat.BallControl => BallControl,
            Stat.Dribbling => Dribbling,
            Stat.TightPossession => TightPossession,
            Stat.LowPass => LowPass,
            Stat.LoftedPass => LoftedPass,
            Stat.Finishing => Finishing,
            Stat.Header => Header,
            Stat.PlaceKicking => PlaceKicking,
            Stat.Curl => Curl,
            Stat.Speed => Speed,
            Stat.Acceleration => Acceleration,
            Stat.KickingPower => KickingPower,
            Stat.Jump => Jump,
            Stat.PhysicalContact => PhysicalContact,
            Stat.Balance => Balance,
            Stat.Stamina => Stamina,
            Stat.DefensiveAwareness => DefensiveAwareness,
            Stat.DefensiveEngagement => DefensiveEngagement,
            Stat.Tackling => Tackling,
            Stat.Aggression => Aggression,
            Stat.GKAwareness => GKAwareness,
            Stat.GKCatching => GKCatching,
            Stat.GKParrying => GKParrying,
            Stat.GKReflexes => GKReflexes,
            Stat.GKReach => GKReach,
            _ => 0
        };
    }
}