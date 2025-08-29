using Core.DataTypes;
using Core.Entities.Clips;

namespace Core.Entities.Edits.Basic;

public class CutClipEdit : IClipEdit {

    public ITimeValue Cut { get; init; }
    
    public CutClipEdit(ITimeValue cut) {
        Cut = cut;
    }

    public void Apply(IClip clip) {
        if (Cut.Seconds >= clip.TimeFrame.Duration.Seconds) {
            throw new InvalidOperationException("Cut cannot be greater than or equal to clip duration");
        }

        var cutLocation = clip.Location + Cut;
        var firstDuration = cutLocation - clip.Location;
        var secondDuration = clip.TimeFrame.Duration - firstDuration;

        var firstTimeFrame = new TimeFrame(
            clip.TimeFrame.Start,
            clip.TimeFrame.Duration - secondDuration
        );

        var secondTimeFrame = new TimeFrame(
            cutLocation,
            secondDuration
        );

        var secondClip = (IClip)clip.Clone();

        clip.SetTimeFrame(firstTimeFrame);
        clip.Move(clip.Location, clip.Track);

        secondClip.SetTimeFrame(secondTimeFrame);
        secondClip.Move(cutLocation, clip.Track);
    }

    public override string ToString() {
        return $"Cut Clip: Cut={Cut}";
    }

}