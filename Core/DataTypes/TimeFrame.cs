namespace Core.DataTypes;

public struct TimeFrame {

    public ITimeValue End => Start + Duration;

    public ITimeValue Start { get; init; }
    public ITimeValue Duration { get; init; }

    public TimeFrame(ITimeValue start, ITimeValue duration) {
        Start = start;
        Duration = duration;
    }

    public static bool operator ==(TimeFrame left, TimeFrame right) {
        return left.Start == right.Start && left.Duration == right.Duration;
    }

    public static bool operator !=(TimeFrame left, TimeFrame right) {
        return !(left == right);
    }

}