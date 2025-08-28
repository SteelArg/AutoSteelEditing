namespace Core.DataTypes.TimeValues;

public struct FramesTimeValue : ITimeValue {

    public float Seconds => _seconds;

    public int Frames { get; init; }
    public int FramesPerSecond { get; init; }

    private readonly float _seconds;

    public FramesTimeValue(int frames, int fps) {
        Frames = frames;
        FramesPerSecond = fps;

        _seconds = frames / fps;
    }

    public static FramesTimeValue FromSeconds(float seconds, int fps) {
        int frames = (int)(seconds * fps);
        return new FramesTimeValue(frames, fps);
    }

    public override string ToString() {
        return $"{Frames} frames ({Seconds} s)";
    }

}