namespace Core.DataTypes.TimeValues;

public struct SecondsTimeValue : ITimeValue {

    public float Seconds { get; init; }

    public SecondsTimeValue(float seconds) {
        Seconds = seconds;
    }

    public override string ToString() {
        return $"{Seconds} s";
    }

}
