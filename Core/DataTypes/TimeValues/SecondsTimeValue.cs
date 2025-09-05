namespace Core.DataTypes.TimeValues;

public struct SecondsTimeValue : ITimeValue {

    public float Seconds { get; init; }

    public static SecondsTimeValue Zero => new SecondsTimeValue(0f);

    public SecondsTimeValue(float seconds) {
        Seconds = seconds;
    }

    public override string ToString() {
        return $"{Seconds} s";
    }

}
