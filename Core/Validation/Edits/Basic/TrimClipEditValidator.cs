using Core.Entities.Edits.Basic;
using Core.Validation.Time;
using FluentValidation;

namespace Core.Validation.Edits.Basic;

public class TrimClipEditValidator : AbstractValidator<TrimClipEdit> {

    public TrimClipEditValidator() {
        RuleFor(x => x.StartTrim)
            .SetValidator(new TimeValueValidator())
            .WithMessage("Start trim must be non-negative");
        RuleFor(x => x.EndTrim)
            .SetValidator(new TimeValueValidator())
            .WithMessage("End trim must be non-negative");
    }

}