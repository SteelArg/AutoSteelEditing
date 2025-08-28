using Core.DataTypes;
using FluentValidation;

namespace Core.Validation.Time;

public class TimeValueValidator : AbstractValidator<ITimeValue> {

    public TimeValueValidator() {
        RuleFor(x => x.Seconds)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Time value must be non-negative.");
    }

}