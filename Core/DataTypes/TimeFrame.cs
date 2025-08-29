namespace Core.DataTypes;

public struct TimeFrame {

    public ITimeValue End => Start + Duration;

    public ITimeValue Start { get; init; }
    public ITimeValue Duration { get; init; }

    public TimeFrame(ITimeValue start, ITimeValue duration) {
        Start = start;
        Duration = duration;
    }

}