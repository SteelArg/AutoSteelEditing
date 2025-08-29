using Core.Entities.Edits.Basic;
using FluentValidation;

namespace Core.Validation.Edits.Basic;

public class TrimClipEditValidator : AbstractValidator<TrimClipEdit> {

    public TrimClipEditValidator() {
        RuleFor(x => x.StartTrim.Seconds)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Start trim must be non-negative");
        RuleFor(x => x.EndTrim.Seconds)
            .GreaterThanOrEqualTo(0)
            .WithMessage("End trim must be non-negative");
    }

}