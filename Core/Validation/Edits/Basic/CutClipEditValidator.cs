using Core.Entities.Edits.Basic;
using FluentValidation;

namespace Core.Validation.Edits.Basic;

public class CutClipValidator : AbstractValidator<CutClipEdit> {

    public CutClipValidator() {
        RuleFor(x => x.Cut.Seconds)
            .GreaterThan(0)
            .WithMessage("Cut must be greater than 0 seconds");
    }

}