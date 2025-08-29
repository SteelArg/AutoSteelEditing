using Core.Entities.Clips;
using Core.Entities.Edits;

namespace Core.Entities.Timelines;

public interface ITimeline : IEditable {

    public string Name { get; }

    public IEnumerable<IClip> Clips { get; }

    public IEnumerable<IVideoClip> VideoClips => Clips.OfType<IVideoClip>();
    public IEnumerable<IAudioClip> AudioClips => Clips.OfType<IAudioClip>();

    public void AddClip(IClip clip);
    public void RemoveClip(IClip clip);

}