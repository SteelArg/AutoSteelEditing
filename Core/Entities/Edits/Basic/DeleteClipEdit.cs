using Core.Entities.Clips;

namespace Core.Entities.Edits.Basic;

public class DeleteClipEdit : IClipEdit {

    public void Apply(IClip clip) {
        if (clip.Timeline == null) {
            throw new InvalidOperationException("Can not delete a clip from null timeline.");
        }

        clip.Timeline.RemoveClip(clip);
    }

}
