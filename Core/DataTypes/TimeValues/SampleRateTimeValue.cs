namespace Core.DataTypes.TimeValues;

public struct SampleRateTimeValue : ITimeValue {

    public float Seconds => _seconds;
    
    public int Samples { get; init; }
    public int SampleRate { get; init; }
    
    private readonly float _seconds;
    
    public SampleRateTimeValue(int samples, int sampleRate) {
        Samples = samples;
        SampleRate = sampleRate;

        _seconds = (float)samples / sampleRate;
    }

    public static SampleRateTimeValue FromSeconds(float seconds, int sampleRate) {
        int samples = (int)(seconds * sampleRate);
        return new SampleRateTimeValue(samples, sampleRate);
    }

    public override string ToString() {
        return $"{Samples} samples ({Seconds} s)";
    }

}