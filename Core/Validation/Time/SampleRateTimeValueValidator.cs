using Core.DataTypes.TimeValues;
using FluentValidation;

namespace Core.Validation.Time;

public class SampleRateTimeValueValidator : AbstractValidator<SampleRateTimeValue> {
    
    public SampleRateTimeValueValidator() {
        RuleFor(x => x.Samples)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Samples time value must be non-negative.");
        RuleFor(x => x.SampleRate)
            .GreaterThan(0)
            .WithMessage("Sample rate must be greater than zero.");
    }

}