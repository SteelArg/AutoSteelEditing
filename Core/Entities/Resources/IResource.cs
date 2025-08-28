using Core.DataTypes;
using Core.DataTypes.MediaTypes;
using Core.DataTypes.TimeValues;
using Core.Entities.Clips;

namespace Core.Entities.Resources;

public interface IResource<out T> where T : Media {

    public string Name { get; }
    public string Path { get; }

    public ITimeValue Duration { get; }

    public IClip<T> CreateClip() => CreateClip(new TimeFrame(new SecondsTimeValue(0f), Duration));
    public IClip<T> CreateClip(TimeFrame timeFrame);

}

public interface IResource : IResource<Media> {

}
