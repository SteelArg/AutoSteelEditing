using Core.DataTypes.TimeValues;

namespace Core.DataTypes;

public interface ITimeValue {

    public float Seconds { get; }

    public static ITimeValue operator +(ITimeValue first, ITimeValue second) {
        return new SecondsTimeValue(first.Seconds + second.Seconds);
    }

    public static ITimeValue operator -(ITimeValue first, ITimeValue second) {
        return new SecondsTimeValue(first.Seconds - second.Seconds);
    }

    public static bool operator <(ITimeValue first, ITimeValue second) {
        return first.Seconds < second.Seconds;
    }

    public static bool operator >(ITimeValue first, ITimeValue second) {
        return first.Seconds > second.Seconds;
    }

}
