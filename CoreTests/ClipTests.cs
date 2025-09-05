using Core.DataTypes;
using Core.DataTypes.TimeValues;
using Core.Entities.Clips;
using CoreTests.Mocks;

namespace CoreTests {

    [TestFixture]
    public class ClipTests {

        private IClip _clip;

        private int _editedCount;

        [SetUp]
        public void Setup() {
            var resource = new MockResource(
                    "Mock Resource",
                    string.Empty,
                    new SecondsTimeValue(5f)
                );

            _clip = new MockClip(
                    resource,
                    new TimeFrame(
                            new SecondsTimeValue(0f),
                            new SecondsTimeValue(3f)
                        ),
                    new SecondsTimeValue(1f),
                    0
                );

            _editedCount = 0;
            _clip.Edited += OnClipEdited;
        }

        [Test]
        public void Duration_Test() {
            Assert.Greater(_clip.TimeFrame.Duration.Seconds, 0f, "Clip must have duration.");
        }

        [Test]
        public void Move_Track_Test() {
            Assert.DoesNotThrow(() => _clip.Move(_clip.Location, 3));

            Assert.Throws<ArgumentException>(() => _clip.Move(_clip.Location, -1));
        }

        [Test]
        public void EditedEvent_Test() {
            int startEditedCount = _editedCount;

            _clip.Move(_clip.Location, _clip.Track);
            _clip.Move(_clip.Location + new SecondsTimeValue(2f), _clip.Track);

            int editedCount = _editedCount - startEditedCount;

            Assert.That(editedCount, Is.EqualTo(1), "Moving a clip must trigger an edited event only for different location and track");
        }

        private void OnClipEdited() {
            _editedCount++;
        }

    }
    
}