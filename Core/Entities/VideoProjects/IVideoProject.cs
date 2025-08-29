using Core.Entities.Edits;
using Core.Entities.Timelines;

namespace Core.Entities.VideoProjects;

public interface IVideoProject : IEditable {

    public string Name { get; }

    public IEnumerable<ITimeline> Timelines { get; }

}