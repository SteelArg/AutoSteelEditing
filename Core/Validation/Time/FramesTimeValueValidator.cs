using Core.DataTypes.TimeValues;
using FluentValidation;

namespace Core.Validation.Time;

public class FramesTimeValueValidator : AbstractValidator<FramesTimeValue> {

    public FramesTimeValueValidator() {
        RuleFor(x => x.Frames)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Frames time value must be non-negative.");
        RuleFor(x => x.FramesPerSecond)
            .GreaterThan(0)
            .WithMessage("Frames per second must be greater than zero.");
    }

}