using Core.DataTypes;
using Core.DataTypes.MediaTypes;
using Core.Entities.Resources;
using Core.Entities.Timelines;

namespace Core.Entities.Clips;

public interface IClip<out T> : ICloneable where T : Media {
    
    public IResource<T> Resource { get; }

    public TimeFrame TimeFrame { get; }
    public ITimeValue Location { get; }
    public int Track { get; }

    public ITimeline Timeline { get; }

    public event Action Changed;

    public void SetTimeline(ITimeline timeline);

    public void Move(ITimeValue location, int track);
    public void SetTimeFrame(TimeFrame timeFrame);

}

public interface IClip : IClip<Media> {

}
