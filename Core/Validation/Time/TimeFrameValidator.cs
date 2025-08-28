using Core.DataTypes;
using FluentValidation;

namespace Core.Validation.Time;

public class TimeFrameValidator : AbstractValidator<TimeFrame> {

    public TimeFrameValidator() {
        RuleFor(x => x.Start)
            .SetValidator(new TimeValueValidator());
        RuleFor(x => x.Duration)
            .SetValidator(new TimeValueValidator());
    }

}