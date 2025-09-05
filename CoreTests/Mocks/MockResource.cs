using Core.DataTypes;
using Core.DataTypes.MediaTypes;
using Core.DataTypes.TimeValues;
using Core.Entities.Clips;
using Core.Entities.Resources;

namespace CoreTests.Mocks {

    public class MockResource(string name, string path, ITimeValue duration) : IResource {

        public string Name { get; init; } = name;
        public string Path { get; init; } = path;
        public ITimeValue Duration { get; init; } = duration;

        public IClip<Media> CreateClip(TimeFrame timeFrame) {
            if (timeFrame.End > Duration) {
                throw new ArgumentException($"{nameof(timeFrame)} cant be outside of the resource duration");
            }

            var mockClip = new MockClip(this, timeFrame, SecondsTimeValue.Zero, 0);

            return mockClip;
        }

    }

}
