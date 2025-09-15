using Core.Entities.Edits.Basic;
using Core.Validation.Time;
using FluentValidation;

namespace Core.Validation.Edits.Basic;

public class CutClipValidator : AbstractValidator<CutClipEdit> {

    public CutClipValidator() {
        RuleFor(x => x.Cut)
            .SetValidator(new TimeValueValidator())
            .WithMessage("Cut must be greater than 0 seconds");
    }

}