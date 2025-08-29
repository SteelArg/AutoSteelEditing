using Core.DataTypes;
using Core.DataTypes.TimeValues;
using Core.Entities.Clips;

namespace Core.Entities.Edits.Basic;

public class TrimClipEdit : IClipEdit {

    public ITimeValue StartTrim { get; init; }
    public ITimeValue EndTrim { get; init; }
    
    public TrimClipEdit(ITimeValue startTrim, ITimeValue endTrim) {
        StartTrim = startTrim;
        EndTrim = endTrim;
    }

    public void Apply(IClip clip) {
        var newLocation = clip.Location + StartTrim;

        var newTimeFrame = new TimeFrame(
            clip.TimeFrame.Start + StartTrim,
            clip.TimeFrame.Duration - StartTrim - EndTrim
        );

        if (newLocation.Seconds < 0) {
            throw new InvalidOperationException("Cannot trim clip to negative start time");
        }

        if (newTimeFrame.Duration.Seconds < 0) {
            throw new InvalidOperationException("Cannot trim clip to negative duration");
        }

        clip.Move(newLocation, clip.Track);
        clip.SetTimeFrame(newTimeFrame);
    }

    public override string ToString() {
        return $"Trim Clip: StartTrim={StartTrim}, EndTrim={EndTrim}";
    }

    public static TrimClipEdit FromStart(ITimeValue startTrim) {
        return new TrimClipEdit(startTrim, new NullTimeValue());
    }

    public static TrimClipEdit FromEnd(ITimeValue endTrim) {
        return new TrimClipEdit(new NullTimeValue(), endTrim);
    }

}