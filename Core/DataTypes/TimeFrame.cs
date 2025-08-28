namespace Core.DataTypes;

public struct TimeFrame {

    public ITimeValue End => new TimeValues.SecondsTimeValue(Start.Seconds + Duration.Seconds);

    public ITimeValue Start { get; init; }
    public ITimeValue Duration { get; init; }

    public TimeFrame(ITimeValue start, ITimeValue duration) {
        Start = start;
        Duration = duration;
    }

}