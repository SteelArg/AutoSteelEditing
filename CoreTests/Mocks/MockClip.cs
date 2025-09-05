using Core.DataTypes;
using Core.DataTypes.MediaTypes;
using Core.Entities.Clips;
using Core.Entities.Resources;
using Core.Entities.Timelines;

namespace CoreTests.Mocks {

    public class MockClip(IResource<Media> resource, TimeFrame timeFrame, ITimeValue location, int track) : IClip {

        public IResource<Media> Resource { get; init; } = resource;

        public TimeFrame TimeFrame { get; private set; } = timeFrame;
        public ITimeValue Location { get; private set; } = location;
        public int Track { get; private set; } = track;

        public ITimeline Timeline { get; private set; }

        public event Action Edited;

        public object Clone() {
            var newClip = new MockClip(Resource, TimeFrame, Location, Track);
            newClip.SetTimeline(Timeline);
            return newClip;
        }

        public void Move(ITimeValue location, int track) {
            if (location.Seconds == Location.Seconds && track == Track)
                return;

            if (track < 0) {
                throw new ArgumentException($"{nameof(track)} cant be less than zero");
            }

            Location = location;
            Track = track;

            Edited?.Invoke();
        }

        public void SetTimeFrame(TimeFrame timeFrame) {
            if (timeFrame == TimeFrame)
                return;

            if (timeFrame.End > Resource.Duration) {
                throw new Exception($"{nameof(timeFrame)} cant be outside of the resource duration");
            }

            TimeFrame = timeFrame;

            Edited?.Invoke();
        }

        public void SetTimeline(ITimeline timeline) {
            if (timeline == Timeline)
                return;
            
            Timeline = timeline;

            Edited?.Invoke();
        }

    }

}
